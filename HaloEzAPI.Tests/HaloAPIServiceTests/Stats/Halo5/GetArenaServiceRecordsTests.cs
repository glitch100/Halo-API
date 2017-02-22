using System.Linq;
using HaloEzAPI.Abstraction.Enum.Halo5;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Stats.Halo5
{
    public class GetArenaServiceRecordsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetArenaServiceRecords(new []{ "Glitch100" }));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetArenaServiceRecords(new[] { "Glitch100" });
            Assert.IsNotNull(result);
        }

        [Test]
        public async void ProvideValidGamertag_ReturnsSingleResult()
        {
            var result = await HaloApiService.GetArenaServiceRecords(new[] { "Glitch100" });
            Assert.IsTrue(result.Results.Count() == 1);
        }

        [Test]
        public async void ProvideInvalidGamertag_ReturnsNotFoundResult()
        {
            var result = await HaloApiService.GetArenaServiceRecords(new[] { "ASFASFEAFEA" });
            Assert.IsTrue(result.Results.FirstOrDefault().ResultCode== ResultCode.NotFound);
        }

        [Test]
        [TestCase("glitch100")]
        [TestCase("mr lushy")]
        [TestCase("swainoo")]
        public async void ProvideValidGamertag_ReturnsSingleResult(string gamertag)
        {
            var result = await HaloApiService.GetArenaServiceRecords(new[] { "Glitch100" });
            Assert.IsTrue(result.Results.Count() == 1);
        }

        [Test]
        [TestCase("glitch100", "swainoo", "mr lushy")]
        public async void ProvideValidGamertagList_ReturnsAll3Result(string gamertag1,string gamertag2,string gamertag3)
        {
            var result = await HaloApiService.GetArenaServiceRecords(new[] { gamertag1,gamertag2,gamertag3});
            Assert.IsTrue(result.Results.Count() == 3);
        }

        [Test]
        [TestCase("glitch100", "swainoo", "mr lushy")]
        public async void ProvideValidGamertagList_ReturnsAll3ResultsWithSuccess(string gamertag1, string gamertag2, string gamertag3)
        {
            var result = await HaloApiService.GetArenaServiceRecords(new[] { gamertag1, gamertag2, gamertag3 });
            Assert.IsTrue(result.Results.ElementAt(0).ResultCode == ResultCode.Success);
            Assert.IsTrue(result.Results.ElementAt(1).ResultCode == ResultCode.Success);
            Assert.IsTrue(result.Results.ElementAt(2).ResultCode == ResultCode.Success);
        }


        [Test]
        [TestCase("glitch100")]
        public async void ProvideValidSeasonId_ReturnsKnownGame(string gamertag1)
        {
            string seasonId = "54c9ee4f-d041-44ef-bd10-2c2f71edb5a4";

            var result = await HaloApiService.GetArenaServiceRecords(new[] { gamertag1 }, seasonId);

            Assert.IsTrue(result.Results.Count() == 1);
            Assert.AreEqual(result.Results.First().Result.ArenaStats.MedalAwards.Count(), 105);
        }

    }
}
