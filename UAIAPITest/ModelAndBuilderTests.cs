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

        PlatformData? platformData;
        PlatformData? platformDataFromBuilder;
        ReleaseData? releaseData;
        ReleaseData? releaseDataFromBuilder;

        [SetUp]
        public void Setup()
        {
            appReleaseData = new Dictionary<string, PlatformData>();
        }

        [Test]
        public void PlatformDataContuctorTest()
        {
            platformData = new PlatformData(signature, url);
            Assert.That(platformData.Signature, Is.EqualTo(signature));
            Assert.That(platformData.Url, Is.EqualTo(url));
        }
        [Test]
        public void ReleaseDataContuctorTest()
        {
            releaseData = new ReleaseData(version, notes, appReleaseData);
            Assert.That(releaseData.Version, Is.EqualTo(version));
            Assert.That(releaseData.Notes, Is.EqualTo(notes));
            Assert.That(releaseData.Platforms, Is.EqualTo(appReleaseData));
        }

        [Test]
        public void PlatformDataBuilderContuctorTest()
        {
            platformDataFromBuilder = new PlatformDataBuilder()
                .SetSignature(signature)
                .SetUrl(url)
                .Build();

            Assert.That(platformDataFromBuilder.Signature, Is.EqualTo(signature));
            Assert.That(platformDataFromBuilder.Url, Is.EqualTo(url));
        }
        [Test]
        public void ReleaseDataBuilderContuctorTest()
        {
            releaseDataFromBuilder = new ReleaseDataBuilder()
                .SetVersion(version)
                .SetNotes(notes)
                .SetPlatform(appReleaseData)
                .AddPlatform(platform, platformData)
                .Build();

            Assert.That(releaseDataFromBuilder.Version, Is.EqualTo(version));
            Assert.That(releaseDataFromBuilder.Notes, Is.EqualTo(notes));
            Assert.That(releaseDataFromBuilder.Platforms, Is.EqualTo(appReleaseData));
        }
    }
}