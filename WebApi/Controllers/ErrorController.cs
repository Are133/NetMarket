using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("errors")]
    [ApiController]
    public class ErrorController : BaseAPIController
    {
        public IActionResult Error(int statusCode)
        {
            return new ObjectResult(new CodeErrorResponse(statusCode));
        }
    }
}
