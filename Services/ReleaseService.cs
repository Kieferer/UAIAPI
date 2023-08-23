using UAIAPI.Models;

namespace UAIAPI.Services
{
    public class ReleaseService
    {
        private Dictionary<string, ReleaseData> projectReleases;
        public ReleaseService()
        {
            projectReleases = new Dictionary<string, ReleaseData>();
        }

    }
}
