using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.UGC
{
    public class GetMapVariantTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetUGCMapVariant("ARC GuiltySpark", "dfb9efd0-53a9-4889-9c63-01f666e8af98"));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetUGCMapVariant("ARC GuiltySpark", "dfb9efd0-53a9-4889-9c63-01f666e8af98");
            Assert.IsNotNull(result);
        }

        [Test]
        public async void ProvideValidDetails_ReturnsKnownProperties()
        {
            const string gamerTag = "ARC GuiltySpark";
            var result = await HaloApiService.GetUGCGameVariant(gamerTag, "dfb9efd0-53a9-4889-9c63-01f666e8af98");
            Assert.AreEqual(gamerTag, result.Identity.Owner);
            Assert.IsNotNull(result);
        }
    }
}