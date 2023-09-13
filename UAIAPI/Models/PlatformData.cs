namespace UAIAPI.Models
{
    public class PlatformData
    {
        public string signature { get; }
        public string url { get; }

        public PlatformData(string signature, string url)
        {
            this.signature = signature;
            this.url = url;
        }
    }
}
