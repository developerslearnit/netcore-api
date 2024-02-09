using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibs.Persistence.IbsAPIEntities
{
    public partial class LoginToken
    {
        public long LoginTokenID { get; set; }

        [StringLength(20)]
        [Required]
        public string Username { get; set; }

        [StringLength(2000)]
        [Required]
        public string AuthToken { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
      
    }
}
