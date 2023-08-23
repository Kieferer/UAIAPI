using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UAIAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : Controller
    {
        public HttpStatusCode Get()
        {
            return HttpStatusCode.OK;
        }
    }
}
