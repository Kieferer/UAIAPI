using UAIAPI.Models;

namespace UAIAPI.DAOs
{
    public class ReleaseDataDAO
    {
        public string name { get; }
        public string version { get; }
        public string notes { get; }
        public DateTime pub_date { get; }
        public Dictionary<string, PlatformData> platforms { get; }

        public ReleaseDataDAO(string name, string version, string notes, Dictionary<string, PlatformData> platforms)
        {
            this.name = name;
            this.version = version;
            this.notes = notes;
            this.pub_date = DateTime.Now;
            this.platforms = platforms;
        }
    }
}
