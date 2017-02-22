using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetMapVariantTests : BaseHaloAPIServiceTests
    {
        private string _validId = "5ce8af68-9986-46fe-98ff-ab09d0878fb7";

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetMapVariant(_validId));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetMapVariant(_validId);
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Success_ReturnsKnownImage()
        {
            var result = await HaloApiService.GetMapVariant(_validId);
            Assert.AreEqual(result.MapImageUrl,
                "https://content.halocdn.com/media/Default/games/halo-5-guardians/map-images/arena/empire-34bb3fecab0e4962844d1fdd436d0bcf.jpg");
        }
    }
}