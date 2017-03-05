using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.HaloWars2
{
    [TestFixture]
    public class GetCamapignLogsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.HaloWars2.GetCampaignLogs());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.HaloWars2.GetCampaignLogs();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.HaloWars2.GetCampaignLogs();
            CollectionAssert.AllItemsAreNotNull(result.ContentItems);
        }

        [Test]
        public async void Default_ReturnsKnownLog()
        {
            var result = await HaloApiService.HaloWars2.GetCampaignLogs();
            var firstLog = result.ContentItems.First();

            Assert.True(result.Paging.TotalCount == 124);
            Assert.True(firstLog.Id == 337005);
            Assert.True(firstLog.View.Title == "The Foundry");
            Assert.True(firstLog.View.HW2Log.Id == 13);
        }
    }
}
