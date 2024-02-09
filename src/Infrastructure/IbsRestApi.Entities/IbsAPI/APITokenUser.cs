using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Entities.IbsAPI;
public class APITokenUser
{
    public int APITokenUserId { get; set; }
    public string Name { get; set; }
    public string LiveToken { get; set; }
    public string TestToken { get; set; }
    public bool Active { get; set; }
}
