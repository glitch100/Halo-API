using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Stats.Halo5
{
    [TestFixture]
    public class GetMatchEventsTests : BaseHaloAPIServiceTests
    {
        [Test]
        [TestCase("3f35f75c-aee4-437a-9b49-535ba2e5f186")]
        public void Default_DoesNotThrowException(string matchId)
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetEventsForMatch(matchId));
        }

        [Test]
        [TestCase("3f35f75c-aee4-437a-9b49-535ba2e5f186")]
        [TestCase("e46d0c1a-9962-44eb-a003-6fac499b0e08")]
        public async void Default_DoesNotReturnNull(string matchId)
        {
            var result = await HaloApiService.GetEventsForMatch(matchId);

            Assert.IsNotNull(result);
        }           
        
        [Test]
        [TestCase("")]
        public async void NoMatchIdProvided_ThrowsException(string matchId)
        {
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetEventsForMatch(matchId), CommonErrorMessages.InvalidMatchId);
        }
    }
}