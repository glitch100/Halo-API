using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.HaloWars2
{
    [TestFixture]
    public class GetCardTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.HaloWars2.GetCards());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.HaloWars2.GetCards();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.HaloWars2.GetCards();
            CollectionAssert.AllItemsAreNotNull(result.ContentItems);
        }

        [Test]
        public async void Default_ReturnsKnownCards()
        {
            var result = await HaloApiService.HaloWars2.GetCards();
            var firstCard = result.ContentItems.First();
            
            Assert.True(firstCard.View.Title == "UNIT_UNSC_WARTHOG_LASTSTAND");
            Assert.True(firstCard.View.HW2Card.EnergyCost == 140);
            Assert.True(firstCard.View.HW2Card.DisplayInfo.View.HW2CardDisplayInfo.SubtypeDescription == "CORE VEHICLE");
        }
    }
}
