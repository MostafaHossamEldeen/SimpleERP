using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Emax.Vansales.Service.Models
{
    public class CutomeReturnHttpAction: IHttpActionResult
    {

            private readonly bool _success;    
            private readonly string _message;
            private readonly HttpStatusCode _statusCode;

            public CutomeReturnHttpAction(HttpStatusCode statusCode, string message,bool success=false)
            {
                _statusCode = statusCode;
                _message = message;
            _success = success;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response = new HttpResponseMessage(_statusCode)
                {
                    Content = new StringContent(_message)
                };
                return Task.FromResult(response);
            }
        }
    
}