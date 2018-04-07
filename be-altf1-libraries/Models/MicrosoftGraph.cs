using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace be.altf1.libraries.Models
{
  public class MicrosoftGraphItem
  {
    public long Id { get; set; }
    public string UserIdentityName { get; set; }
    private string _userContainer;
    public string UserContainer
    {
      get
      {
        return getUserContainer(this._userContainer);
      }
      set { this._userContainer = value; }
    }

    private string getUserContainer(string UserIdentityName)
    {
      return UserIdentityName.Replace(".", "-pnt-").Replace("#", "-hsh-").Replace("_", "-und-").Replace("@", "-at-");
    }
  }
}
