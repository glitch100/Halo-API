using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Stats
{
    [TestFixture]
    public class PlayerLeaderboardTests : BaseHaloAPIServiceTests
    {
        [Test]
        [TestCase("6080b0bc-95fc-457d-8982-c43801258182", "892189e9-d712-4bdb-afa7-1ccab43fbed4")]
        public void Default_DoesNotThrowException(string seasonId, string playlistId)
        {
            Assert.DoesNotThrow(async () => await HaloApiService.PlayerLeaderboard(seasonId, playlistId));
        }

        [Test]
        [TestCase("6080b0bc-95fc-457d-8982-c43801258182", "892189e9-d712-4bdb-afa7-1ccab43fbed4")]
        public async void Default_DoesNotReturnNull(string seasonId, string playlistId)
        {
            var result = await HaloApiService.PlayerLeaderboard(seasonId, playlistId);

            Assert.IsNotNull(result);
        }        

        [Test]
        [TestCase("6080b0bc-95fc-457d-8982-c43801258182", "892189e9-d712-4bdb-afa7-1ccab43fbed4")]
        public async void ValidRequest_Returns200ByDefault(string seasonId, string playlistId)
        {
            var result = await HaloApiService.PlayerLeaderboard(seasonId, playlistId);

            Assert.True(result.Count == 200);
        }        

    }
}