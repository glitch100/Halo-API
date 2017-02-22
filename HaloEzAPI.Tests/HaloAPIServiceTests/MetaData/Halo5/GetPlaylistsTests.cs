using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetPlaylistsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetPlaylists());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetPlaylists();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetPlaylists();
            CollectionAssert.AllItemsAreNotNull(result);
        }
    }
}