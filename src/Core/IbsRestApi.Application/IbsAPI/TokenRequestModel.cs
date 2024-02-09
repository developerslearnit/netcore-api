using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.IbsAPI;
public class TokenRequestModel
{
    public string consumerKey { get; set; }

    public string consumerSecret { get; set; }
}

public class TokenRequestmodel
{
    public string client_id { get; set; }

    public string grant_type { get; set; }
}
