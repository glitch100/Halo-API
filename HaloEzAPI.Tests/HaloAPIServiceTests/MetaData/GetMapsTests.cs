using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData
{
    [TestFixture]
    public class GetMapsTests : BaseHaloAPIServiceTests
    {
        private string _validId = "5ce8af68-9986-46fe-98ff-ab09d0878fb7";

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetMaps());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetMaps();
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("https://content.halocdn.com/media/Default/games/halo-5-guardians/map-images/campaign/campaign_missions_array12-901b0025b17b4667ae8038239e692584.jpg")]
        [TestCase("https://content.halocdn.com/media/Default/games/halo-5-guardians/map-images/arena/arena_maps_array01-255ee5e1de7f4a48ae47077f24b216ff.jpg")]
        [TestCase("https://content.halocdn.com/media/Default/games/halo-5-guardians/map-images/arena/eden-7fd2ba70e3cc4b62af990ba4f072e770.jpg")]
        public async void Success_ReturnsKnownImage(string imageUrl)
        {
            var result = await HaloApiService.GetMapVariant(_validId);
            Assert.AreEqual(result.MapImageUrl,"https://content.halocdn.com/media/Default/games/halo-5-guardians/map-images/arena/empire-34bb3fecab0e4962844d1fdd436d0bcf.jpg");
        }
    }
}