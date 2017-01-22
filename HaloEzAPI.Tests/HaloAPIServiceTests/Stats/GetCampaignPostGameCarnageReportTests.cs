using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Stats
{
    [TestFixture]
    public class GetCampaignPostGameCarnageReportTests : BaseHaloAPIServiceTests
    {
        private static readonly Guid _validGuid = new Guid("acc04b23-ba22-490b-a842-5c9e7ece4298");

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetCampaignPostGameCarnageReport(_validGuid));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetCampaignPostGameCarnageReport(_validGuid);
            Assert.IsNotNull(result);
        }

        [Test]
        public async void ProvideValidMatchId_ReturnsKnownPlayer()
        {
            var result = await HaloApiService.GetCampaignPostGameCarnageReport(_validGuid);
            Assert.IsTrue(result.PlayerStats.Any(ps=>ps.Player.Gamertag.Equals("Glitch100",StringComparison.InvariantCultureIgnoreCase)));
        }        
    }
}