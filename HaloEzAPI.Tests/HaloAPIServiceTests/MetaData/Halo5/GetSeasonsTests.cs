using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetSeasonsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetSeasons());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetSeasons();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetSeasons();
            CollectionAssert.AllItemsAreNotNull(result);
        }

        [Test]
        public async void Default_PlaylistsNotEmpty()
        {
            var result = await HaloApiService.GetSeasons();
            Assert.True(result.All(r=>r.Playlists.Any()));
        }
    }
}
