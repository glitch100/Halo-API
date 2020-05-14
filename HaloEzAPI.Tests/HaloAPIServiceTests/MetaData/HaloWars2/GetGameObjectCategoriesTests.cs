using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.HaloWars2
{
    [TestFixture]
    public class GetGameObjectCategoriesTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.HaloWars2.GetGameObjectCategories());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.HaloWars2.GetGameObjectCategories();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.HaloWars2.GetGameObjectCategories();
            CollectionAssert.AllItemsAreNotNull(result.ContentItems);
        }

        [Test]
        public async void Default_ReturnsKnownGameObjectCategory()
        {
            var result = await HaloApiService.HaloWars2.GetGameObjectCategories();
            var firstGameObjectCat = result.ContentItems.First();
            
            Assert.AreEqual(firstGameObjectCat.View.Title, "Anti-Infantry [obj category]");
        }
    }
}
