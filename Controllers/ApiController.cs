using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UAIAPI.Builders;
using UAIAPI.DAOs;
using UAIAPI.Models;
using UAIAPI.Services;

namespace UAIAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly ReleaseService releaseService;
        public ApiController(ReleaseService releaseService)
        {
            this.releaseService = releaseService;
        }
     
        [HttpPost("update")]
        public IActionResult SetUpdateData([FromBody] ReleaseDataDAO releaseDataDAO)
        {
            ReleaseData releaseData = new ReleaseDataBuilder()
                .SetVersion(releaseDataDAO.version)
                .SetNotes(releaseDataDAO.notes)
                .SetPlatform(releaseDataDAO.platforms)
            .Build();

            releaseService.SetOrUpdateRelease(releaseDataDAO.name, releaseData);

            string output = $"${releaseDataDAO.name} is updated in the server with its latest (${releaseData.version}) version." +
                $"Stored projects: ${releaseService.GetProjectCount()}";

            return Content(output, "text/plain");
        }

        [HttpGet("update/{projectName}")]
        public IActionResult GetUpdateData(string projectName)
        {
            var releaseData = releaseService.GetReleaseData(projectName);

            if (releaseData == null)
            {
                return NotFound();
            }

            string serializedReleaseData = JsonConvert.SerializeObject(releaseData, Formatting.Indented);
            return Content(serializedReleaseData, "application/json");
        }
    }
}
