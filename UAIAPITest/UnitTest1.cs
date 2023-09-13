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

        [Test]
        public void platformDataTest()
        {
            Assert.That(platformData.Signature, Is.EqualTo(signature));
            Assert.That(platformData.Url, Is.EqualTo(url));
        }
        [Test]
        public void releaseDataTest()
        {
            Assert.That(releaseData.Version, Is.EqualTo(version));
            Assert.That(releaseData.Notes, Is.EqualTo(notes));
            Assert.That(releaseData.Platforms, Is.EqualTo(appReleaseData));
        }

        [Test]
        public void platformDataFromBuilderTest()
        {
            Assert.That(platformDataFromBuilder.Signature, Is.EqualTo(signature));
            Assert.That(platformDataFromBuilder.Url, Is.EqualTo(url));
        }
        [Test]
        public void releaseDataFromBuilderTest()
        {
            Assert.That(releaseDataFromBuilder.Version, Is.EqualTo(version));
            Assert.That(releaseDataFromBuilder.Notes, Is.EqualTo(notes));
            Assert.That(releaseDataFromBuilder.Platforms, Is.EqualTo(appReleaseData));
        }
    }
}