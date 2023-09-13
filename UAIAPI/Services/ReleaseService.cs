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
        public virtual void SetOrUpdateRelease(string name,  ReleaseData release)
        {
            projectReleases[name] = release;
        }
        public virtual ReleaseData? GetReleaseData(string projectName)
        {
            if (projectReleases.TryGetValue(projectName, out ReleaseData? releaseData))
            {
                return releaseData;
            }
            return null;
        }
        public int GetProjectCount()
        {
            return projectReleases.Count;
        }
    }
}
