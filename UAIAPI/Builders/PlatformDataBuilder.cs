using UAIAPI.Models;

namespace UAIAPI.Builders
{
    public class PlatformDataBuilder
    {
        private string? Signature;
        private string? Url;

        public PlatformDataBuilder SetSignature(string signature)
        {
            Signature = signature;
            return this;
        }

        public PlatformDataBuilder SetUrl(string url)
        {
            Url = url;
            return this;
        }

        public PlatformData Build()
        {
            return new PlatformData(Signature, Url);
        }
    }
}
