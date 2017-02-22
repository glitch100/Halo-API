using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Stats.Halo5
{
    [TestFixture]
    public class GetWarzonePostGameCarnageReportTests : BaseHaloAPIServiceTests
    {
        private static readonly Guid _validGuid = new Guid("49085a46-5784-471c-bd04-9dafb26e7f8f");

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetWarzonePostGameCarnageReport(_validGuid));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetWarzonePostGameCarnageReport(_validGuid);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("Glitch100")]
        public async void ProvideValidMatchId_ReturnsKnownPlayer(string gamerTag)
        {
            var result = await HaloApiService.GetWarzonePostGameCarnageReport(_validGuid);
            Assert.IsTrue(
                result.PlayerStats.Any(
                    ps => ps.Player.Gamertag.Equals(gamerTag, StringComparison.InvariantCultureIgnoreCase)));
        }

        [Test]
        public async void ProvideValidMatchId_ReturnsKnownMapId()
        {
            var result = await HaloApiService.GetWarzonePostGameCarnageReport(_validGuid);
            Assert.AreEqual(result.MapId, new Guid("cb251c51-f206-11e4-8541-24be05e24f7e"));
        }

        [Test]
        public async void ProvideValidMatchId_ReturnsKnownDuration()
        {
            var result = await HaloApiService.GetWarzonePostGameCarnageReport(_validGuid);
            Assert.AreEqual(result.TotalDuration.ToString(), "00:17:16.8890008");
        }

        [Test]
        [TestCase("ea392dc3-5989-4fa8-b920-08e265220ffc")]
        public async void ProvideValidMatchId_MetaCommendationDeltasAreSet(string matchId)
        {
            var result = await HaloApiService.GetWarzonePostGameCarnageReport(new Guid(matchId));

            // The player earned the final level of the "Assistant" Meta commendation
            var player = result.PlayerStats.FirstOrDefault(ps => ps.Player.Gamertag == "larry chimp man");
            Assert.IsNotNull(player, "Player should exist in results");
            var guid = player.MetaCommendationDeltas.First().PreviousMetRequirements.First().Guid;
            Assert.AreEqual(new Guid("7077a782-ccba-4b0b-b2fd-5023a61fbb4c"), guid, "Requirement guid should be correct");
        }
    }
}