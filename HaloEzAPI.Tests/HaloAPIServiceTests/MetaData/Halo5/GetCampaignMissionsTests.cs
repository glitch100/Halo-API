using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetCampaignMissionsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetCampaignMissions());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetCampaignMissions();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetCampaignMissions();
            CollectionAssert.AllItemsAreNotNull(result);
        }

        [Test]
        public async void Default_ReturnsKnownMission()
        {
            var result = await HaloApiService.GetCampaignMissions();
            Assert.IsTrue(result.Any(r => r.Id == new Guid("73ed1fd0-45e5-4bb9-ab6a-d2852c04ea7d")));
        }
    }
}
