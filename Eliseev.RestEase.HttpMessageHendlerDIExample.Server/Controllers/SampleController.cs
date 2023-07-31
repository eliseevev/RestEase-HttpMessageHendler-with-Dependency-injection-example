using Eliseev.RestEase.HttpMessageHendlerDIExample.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Eliseev.RestEase.HttpMessageHendlerDIExample.Server.Controllers
{
    [ApiController]
    [Route(ISampleController.Routes.BasePath)]
    public class SampleController : ControllerBase, ISampleController
    {
        [HttpGet]
        public Task<string> GetRequestTestHeaderValue()
        {
            var testHeaderValue =
                this.HttpContext.Request.Headers
                    .Single(header => header.Key ==  HttpHeaders.TestHeader)
                    .Value
                    .Single();

            return Task.FromResult(testHeaderValue);
        }
    }
}