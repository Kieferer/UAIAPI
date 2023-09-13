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
            Assert.That(platformData.signature, Is.EqualTo(signature));
            Assert.That(platformData.url, Is.EqualTo(url));
        }
        [Test]
        public void ReleaseDataContuctorTest()
        {
            releaseData = new ReleaseData(version, notes, appReleaseData);
            Assert.That(releaseData.version, Is.EqualTo(version));
            Assert.That(releaseData.notes, Is.EqualTo(notes));
            Assert.That(releaseData.platforms, Is.EqualTo(appReleaseData));
        }

        [Test]
        public void PlatformDataBuilderContuctorTest()
        {
            platformDataFromBuilder = new PlatformDataBuilder()
                .SetSignature(signature)
                .SetUrl(url)
                .Build();

            Assert.That(platformDataFromBuilder.signature, Is.EqualTo(signature));
            Assert.That(platformDataFromBuilder.url, Is.EqualTo(url));
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

            Assert.That(releaseDataFromBuilder.version, Is.EqualTo(version));
            Assert.That(releaseDataFromBuilder.notes, Is.EqualTo(notes));
            Assert.That(releaseDataFromBuilder.platforms, Is.EqualTo(appReleaseData));
        }
    }
}