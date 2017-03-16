using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.HaloWars2
{
    [TestFixture]
    public class GetCSRDesignationsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.HaloWars2.GetCSRDesignations());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.HaloWars2.GetCSRDesignations();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.HaloWars2.GetCSRDesignations();
            CollectionAssert.AllItemsAreNotNull(result.ContentItems);
        }

        [Test]
        public async void Default_ReturnsKnownCSRDesignation()
        {
            var result = await HaloApiService.HaloWars2.GetCSRDesignations();
            var firstCard = result.ContentItems.First();
            
            Assert.True(firstCard.View.HW2CsrDesignation.DisplayInfo.View.HW2CsrDesignationDisplayInfo.Name == "Gold");
        }

        [Test]
        public async void Default_ReturnsKnownCSRDesignationTierId()
        {
            var result = await HaloApiService.HaloWars2.GetCSRDesignations();
            var firstCard = result.ContentItems.First();

            Assert.AreEqual(firstCard.View.HW2CsrDesignation.Tiers.First().View.HW2CsrDesignationTier.ID, 1);
        }

        [Test]
        public async void Default_ReturnsKnownCSRDesignationTier()
        {
            var result = await HaloApiService.HaloWars2.GetCSRDesignations();
            var firstCard = result.ContentItems.First();

            Assert.True(firstCard.View.HW2CsrDesignation.Tiers.First().View.HW2CsrDesignationTier.Image.View.Media.FileName.Contains("csr_gold_array"));
        }
    }
}
