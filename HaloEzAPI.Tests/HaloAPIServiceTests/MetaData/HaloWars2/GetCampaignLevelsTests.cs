using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.HaloWars2
{
    [TestFixture]
    public class GetCampaignLevelsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.HaloWars2.GetCampaignLevels());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.HaloWars2.GetCampaignLevels();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.HaloWars2.GetCampaignLevels();
            CollectionAssert.AllItemsAreNotNull(result.ContentItems);
        }

        [Test]
        public async void Default_ReturnsKnownMission()
        {
            var result = await HaloApiService.HaloWars2.GetCampaignLevels();
            var firstMission = result.ContentItems.First();

            Assert.True(result.Paging.TotalCount == 15);
            Assert.True(firstMission.Id == 337329);
            Assert.True(firstMission.View.Title == "LIGHTS OUT");
            Assert.True(firstMission.View.Hw2CampaignLevel.Id == 400);
        }
    }
}
