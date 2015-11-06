using System;
using System.Linq;
using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Stats
{
    [TestFixture]
    public class GetArenaPostGameCarnageReportTests : BaseHaloAPIServiceTests
    {
        private static readonly Guid _validGuid = new Guid("7afbfebe-9a05-4f22-bff2-c7eb62dc1f65");
        
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetArenaPostGameCarnageReport(_validGuid));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetArenaPostGameCarnageReport(_validGuid);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("7afbfebe-cccc-cccc-cccc-c7eb62dc1f65")]
        public async void ProvideInvalidMatchId_ThrowsException(string matchId) 
        {
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetArenaPostGameCarnageReport(new Guid(matchId)), CommonErrorMessages.InvalidMatchId);
        }

        [Test]
        public async void ProvideValidMatchId_PlayersHasKnownGamer()
        {
            var result = await HaloApiService.GetArenaPostGameCarnageReport(_validGuid);
            Assert.IsTrue(result.PlayerStats.Any(ps => ps.Player.Gamertag == "Glitch100"));
        }

        [Test]
        public async void ProvideValidMatchId_PlayersDoesntHaveRandom()
        {
            var result = await HaloApiService.GetArenaPostGameCarnageReport(_validGuid);
            Assert.IsFalse(result.PlayerStats.Any(ps => ps.Player.Gamertag == "CCCCCCCCCCCCCCCCCCCC"));
        }
    }
}
