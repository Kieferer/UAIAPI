namespace UAIAPI.Models
{
    public class ReleaseData
    {
        public string Version { get; }
        public string Notes { get; }
        public DateTime PubDate { get; }
        public Dictionary<string, PlatformData> Platforms { get; }

        public ReleaseData(string version, string notes, Dictionary<string, PlatformData> platforms)
        {
            Version = version;
            Notes = notes;
            PubDate = DateTime.Now;
            Platforms = platforms;
        }
    }
}
