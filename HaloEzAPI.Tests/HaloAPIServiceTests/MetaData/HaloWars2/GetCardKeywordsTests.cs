using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.HaloWars2
{
    [TestFixture]
    public class GetCardKeywords : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.HaloWars2.GetCardKeywords());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.HaloWars2.GetCardKeywords();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.HaloWars2.GetCardKeywords();
            CollectionAssert.AllItemsAreNotNull(result.ContentItems);
        }

        [Test]
        public async void Default_ReturnsKnownKeyword()
        {
            var result = await HaloApiService.HaloWars2.GetCardKeywords();
            var firstLog = result.ContentItems.First();

            Assert.True(firstLog.Id == 337156);
            Assert.True(firstLog.View.Title == "Rally");
            Assert.True(firstLog.View.HW2CardKeyword.Keyword == "Rally");
        }
    }
}
