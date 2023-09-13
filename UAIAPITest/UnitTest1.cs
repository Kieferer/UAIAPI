using UAIAPI.Builders;
using UAIAPI.Models;

namespace UAIAPITest
{
    public class Tests
    {
        readonly string version = "testVersion";
        readonly string notes = "testNotes";
        readonly string signature = "testSig";
        readonly string url = "testURL";
        readonly string platform = "testPlatform";

        Dictionary<string, PlatformData> appReleaseData;

        PlatformData platformData;
        PlatformData platformDataFromBuilder;
        ReleaseData releaseData;
        ReleaseData releaseDataFromBuilder;

        [SetUp]
        public void Setup()
        {
            appReleaseData = new Dictionary<string, PlatformData>();

            platformData = new PlatformData(signature, url);
            releaseData = new ReleaseData(version, notes, appReleaseData);

            platformDataFromBuilder = new PlatformDataBuilder()
                .SetSignature(signature)
                .SetUrl(url)
                .Build();

            releaseDataFromBuilder = new ReleaseDataBuilder()
                .SetVersion(version)
                .SetNotes(notes)
                .SetPlatform(appReleaseData)
                .AddPlatform(platform, platformData)
                .Build();
        }
    }
}