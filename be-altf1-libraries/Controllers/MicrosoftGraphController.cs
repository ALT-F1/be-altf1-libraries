using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using be.altf1.libraries.Models;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using Microsoft.ApplicationInsights;

namespace be_altf1_libraries.Controllers
{


  [Route("api/[controller]")]
  public class MicrosoftGraphController : Controller
  {
    private TelemetryClient telemetry = new TelemetryClient();
    private readonly MicrosoftGraphContext _context;
    public MicrosoftGraphController(MicrosoftGraphContext context)
    {
      _context = context;

      if (_context.MicrosoftGraphItems.Count() == 0)
      {
        // ConfigurationManager.AppSettings["be:alt-f1:libraries:UserIdentityName"] 
        _context.MicrosoftGraphItems.Add(new MicrosoftGraphItem { UserIdentityName = "identity#belgium@altf1.be", UserContainer = "identity#belgium@altf1.be" });
        _context.SaveChanges();
      }
    }

    [HttpGet]
    public IEnumerable<MicrosoftGraphItem> GetAll()
    {
      telemetry.TrackTrace("HttpGet: " + JsonConvert.SerializeObject(_context.MicrosoftGraphItems.ToList()));
      return _context.MicrosoftGraphItems.ToList();
    }

    [HttpGet("{id}", Name = "GetMicrosoftGraph")]
    public IActionResult GetById(long id)
    {
      var item = _context.MicrosoftGraphItems.FirstOrDefault(t => t.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      telemetry.TrackTrace("HttpGet/" + id + ": " + JsonConvert.SerializeObject(item));
      return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult Create([FromBody] MicrosoftGraphItem item)
    {
      if (item == null)
      {
        return BadRequest();
      }

      _context.MicrosoftGraphItems.Add(item);
      _context.SaveChanges();

      System.Diagnostics.Trace.TraceInformation("HttpPost: {0}", JsonConvert.SerializeObject(item));
      telemetry.TrackTrace("HttpPost: " + JsonConvert.SerializeObject(item));

      return CreatedAtRoute("GetMicrosoftGraph", new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] MicrosoftGraphItem item)
    {
      if (item == null || item.Id != id)
      {
        return BadRequest();
      }

      var MicrosoftGraph = _context.MicrosoftGraphItems.FirstOrDefault(t => t.Id == id);
      if (MicrosoftGraph == null)
      {
        return NotFound();
      }

      MicrosoftGraph.UserContainer = item.UserContainer;
      MicrosoftGraph.UserIdentityName = item.UserIdentityName;

      _context.MicrosoftGraphItems.Update(MicrosoftGraph);
      _context.SaveChanges();
      System.Diagnostics.Trace.TraceInformation("HttpPut: {0}", JsonConvert.SerializeObject(item));
      telemetry.TrackTrace("HttpPut: " + JsonConvert.SerializeObject(item));
      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var microsoftGraph = _context.MicrosoftGraphItems.FirstOrDefault(t => t.Id == id);
      if (microsoftGraph == null)
      {
        return NotFound();
      }

      _context.MicrosoftGraphItems.Remove(microsoftGraph);
      _context.SaveChanges();
      System.Diagnostics.Trace.TraceInformation("HttpDelete: {0}", JsonConvert.SerializeObject(microsoftGraph));
      telemetry.TrackTrace("HttpDelete: " + JsonConvert.SerializeObject(microsoftGraph));
      return new NoContentResult();
    }

  }
}