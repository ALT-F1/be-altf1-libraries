using be.altf1.libraries.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace be.altf1.libraries.Models
{
  // The database context is the main class that coordinates Entity Framework functionality for a given data model.
  public class MicrosoftGraphContext : DbContext
  {
    public MicrosoftGraphContext(DbContextOptions<MicrosoftGraphContext> options)
        : base(options)
    {
    }

    public DbSet<MicrosoftGraphItem> MicrosoftGraphItems { get; set; }

  }
}
