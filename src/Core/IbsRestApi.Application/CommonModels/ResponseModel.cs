using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.CommonModels;
public class ResponseModel
{
    public int StatusCode { get; set; } = 200;

    public bool HasError { get; set; } = false;

    public string Message { get; set; } = string.Empty;

    public object data { get; set; } = null;
}
