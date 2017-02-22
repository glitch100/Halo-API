using System;
using System.Linq;
using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Stats.Halo5
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
            Assert.Throws<HaloAPIException>(
                async () => await HaloApiService.GetArenaPostGameCarnageReport(new Guid(matchId)),
                CommonErrorMessages.InvalidMatchId);
        }

        [Test]
        public async void ProvideValidMatchId_PlayersHasKnownGamer()
        {
            var result = await HaloApiService.GetArenaPostGameCarnageReport(_validGuid);
            Assert.IsTrue(result.PlayerStats.Any(ps => ps.Player.Gamertag == "Glitch100"));
        }

        [Test]
        public async void ProvideValidMatchId_CanRetrieveKnownImpulse()
        {
            var result = await HaloApiService.GetArenaPostGameCarnageReport(new Guid("e46d0c1a-9962-44eb-a003-6fac499b0e08"));
            Assert.IsTrue(result.PlayerStats.Any(ps => ps.Player.Gamertag == "Glitch100"));
        }

        [Test]
        public async void ProvideValidMatchId_ValidData()
        {
            var result =
                await HaloApiService.GetArenaPostGameCarnageReport(new Guid("3f35f75c-aee4-437a-9b49-535ba2e5f186"));
            Assert.IsTrue(result.PlayerStats.Any(ps => ps.Player.Gamertag == "Glitch100"));
        }

        [Test]
        public async void ProvideValidMatchId_PlayersDoesntHaveRandom()
        {
            var result = await HaloApiService.GetArenaPostGameCarnageReport(_validGuid);
            Assert.IsFalse(result.PlayerStats.Any(ps => ps.Player.Gamertag == "CCCCCCCCCCCCCCCCCCCC"));
        }

        [Test]
        [TestCase("eaba11d8-ac94-432d-85f9-aed32d294e91")]
        public async void ProvideValidMatchId_MetaCommendationDeltasAreSet(string matchId)
        {
            var result = await HaloApiService.GetArenaPostGameCarnageReport(new Guid(matchId));

            // The player earned the final level of the "Storm the Walls" Meta commendation
            var player = result.PlayerStats.FirstOrDefault(ps => ps.Player.Gamertag == "N 2the eighbor");
            Assert.IsNotNull(player, "Player should exist in results");
            var guid = player.MetaCommendationDeltas.First().PreviousMetRequirements.First().Guid;
            Assert.AreEqual(new Guid("af14745e-776d-4307-8e1d-3c0fa0520464"), guid, "Requirement guid should be correct");
        }
    }
}
