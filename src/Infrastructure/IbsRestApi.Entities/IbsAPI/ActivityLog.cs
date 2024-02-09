using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibs.Persistence.IbsAPIEntities
{
    public partial class ActivityLog
    {
        public Guid ActivityLogId { get; set; }

        [StringLength(10)]
        public string LogType { get; set; }

        [StringLength(500)]
        public string Endpoint { get; set; }

        [StringLength(10)]
        public string HttpRequestType { get; set; }

        [StringLength(2000)]
        public string RequestBody { get; set; }

        [StringLength(3000)]
        public string Message { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime RequestStartDate { get; set; }

        public DateTime RequestEndDate { get; set; }

        [StringLength(103)]
        public string CallerAPIKey { get; set; }

        [StringLength(10)]
        public string API_ID { get; set; }
    }
}
