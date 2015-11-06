using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.GetMatchesForPlayerTests
{
    [TestFixture]
    public class GetMatchesForPlayerTests : BaseHaloAPIServiceTests
    {
        [TestCase("Glitch100", GameMode.Arena)]
        public void Default_DoesNotThrowException(string gamerTag,GameMode gameMode)
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetMatchesForPlayer(gamerTag, gameMode));
        }

        [TestCase("Glitch100", GameMode.Arena)]
        public async void Default_DoesNotReturnNull(string gamerTag,GameMode gameMode)
        {
            var result = await HaloApiService.GetMatchesForPlayer(gamerTag, gameMode);
            Assert.IsNotNull(result);
        }

        [TestCase("",GameMode.Arena)]
        [TestCase(null,GameMode.Arena)]
        [TestCase("asfasd9f8adf89andfa98sdfa",GameMode.Arena)]
        public void ProvideInvalidGamertag_ThrowsException(string gamerTag,GameMode gameMode)
        {
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetMatchesForPlayer(gamerTag, gameMode), CommonErrorMessages.InvalidGamerTag);
        }

        [TestCase("Glitch100")]
        public async void ProvideValidGamertag_GetValidReponse(string gamerTag)
        {
            var result = await HaloApiService.GetMatchesForPlayer(gamerTag, GameMode.All);
            Assert.AreEqual(result.Count,25);
        }

        [TestCase("Glitch100",5,10)]
        [TestCase("Glitch100",6,15)]
        public async void ProvideStartAndCount_GetValidReponse(string gamerTag,int start, int count)
        {
            var result = await HaloApiService.GetMatchesForPlayer(gamerTag, GameMode.All, start, count);
            Assert.AreEqual(result.Count, count);
            Assert.AreEqual(result.Start, start);
        }
    }
}
