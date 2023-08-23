namespace UAIAPI.Models
{
    public class PlatformData
    {
        public string Signature { get; }
        public string Url { get; }

        public PlatformData(string signature, string url)
        {
            Signature = signature;
            Url = url;
        }
    }
}
