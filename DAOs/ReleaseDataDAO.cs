using UAIAPI.Models;

namespace UAIAPI.DAOs
{
    public class ReleaseDataDAO
    {
        public string Name { get; }
        public string Version { get; }
        public string Notes { get; }
        public DateTime PubDate { get; }
        public Dictionary<string, PlatformData> Platforms { get; }

        public ReleaseDataDAO(string name, string version, string notes, Dictionary<string, PlatformData> platforms)
        {
            Name = name;
            Version = version;
            Notes = notes;
            PubDate = DateTime.Now;
            Platforms = platforms;
        }
    }
}
