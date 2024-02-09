using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibs.Persistence.IbsAPIEntities
{
    public partial class APIUser
    {
        public Guid ApiUserId { get; set; }
        public string APIKey { get; set; }
        public string APISecret { get; set; }
        public string HashedAPIKey { get; set; }
        public string HashedAPISecret { get; set; }
        public string HashSalt { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
