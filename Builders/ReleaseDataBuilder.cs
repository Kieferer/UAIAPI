using System;
using UAIAPI.Models;

namespace UAIAPI.Builders
{
    public class ReleaseDataBuilder
    {
        private string? Version;
        private string? Notes;
        private Dictionary<string, PlatformData> Platforms = new Dictionary<string, PlatformData>();

        public ReleaseDataBuilder SetVersion(string version)
        {
            Version = version;
            return this;
        }

        public ReleaseDataBuilder SetNotes(string notes)
        {
            Notes = notes;
            return this;
        }

        public ReleaseDataBuilder SetPlatform(Dictionary<string, PlatformData> platforms)
        {
            Platforms = platforms;
            return this;
        }

        public ReleaseDataBuilder AddPlatform(string platform, PlatformData platformInfo)
        {
            Platforms.Add(platform, platformInfo);
            return this;
        }

        public ReleaseData Build()
        {
            return new ReleaseData(Version, Notes, Platforms);
        }
    }
}
