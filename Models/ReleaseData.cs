namespace UAIAPI.Models
{
    public class ReleaseData
    {
        public string version { get; }
        public string notes { get; }
        public DateTime pub_date { get; }
        public Dictionary<string, PlatformData> platforms { get; }

        public ReleaseData(string version, string notes, Dictionary<string, PlatformData> platforms)
        {
            this.version = version;
            this.notes = notes;
            this.pub_date = DateTime.Now;
            this.platforms = platforms;
        }
    }
}
