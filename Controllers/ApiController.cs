using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using UAIAPI.Builders;
using UAIAPI.DAOs;
using UAIAPI.Models;

namespace UAIAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        Dictionary<string, ReleaseData> projectData = new Dictionary<string, ReleaseData>();
        [HttpPost("update")]
        public IActionResult SetUpdateData([FromBody] ReleaseDataDAO releaseDataDAO)
        {
            ReleaseData releaseData = new ReleaseDataBuilder()
                .SetVersion(releaseDataDAO.Version)
                .SetNotes(releaseDataDAO.Notes)
                .SetPlatform(releaseDataDAO.Platforms)
                .Build();

            string output;
            string NameOfProject = releaseDataDAO.Name;
            if (projectData.ContainsKey(NameOfProject))
            {
                projectData[NameOfProject] = releaseData;
                output = $"${NameOfProject} is updated in the server with its latest (${releaseData.Version}) version. Stored projects: ${projectData.Keys.Count}";
            }
            else
            {
                projectData.Add(releaseDataDAO.Name, releaseData);
                output = $"${NameOfProject} is registered to the server with its latest (${releaseData.Version}) version. Stored projects: ${projectData.Keys.Count}";
            }

            //string BackToJSONFormatForTest = JsonConvert.SerializeObject(releaseData, Formatting.Indented);
            return Content(output, "application/text");
        }

        [HttpGet("update")]
        public IActionResult GetUpdateData()
        {
            throw new NotImplementedException();
        }
    }
}
