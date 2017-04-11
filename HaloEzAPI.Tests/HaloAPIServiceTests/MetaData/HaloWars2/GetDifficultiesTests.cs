using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.HaloWars2
{
    [TestFixture]
    public class GeDifficultiesTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.HaloWars2.GetDifficulties());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.HaloWars2.GetDifficulties();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.HaloWars2.GetDifficulties();
            CollectionAssert.AllItemsAreNotNull(result.ContentItems);
        }

        [Test]
        public async void Default_ReturnsKnownDifficulty()
        {
            var result = await HaloApiService.HaloWars2.GetDifficulties();
            var firstDifficulty = result.ContentItems.First();
            
            Assert.True(firstDifficulty.View.HW2Difficulty.DisplayInfo.View.HW2DifficultyDisplayInfo.Name == "Normal");
        }

        [Test]
        public async void Default_ReturnsKnownId()
        {
            var result = await HaloApiService.HaloWars2.GetDifficulties();
            var firstCard = result.ContentItems.First();

            Assert.AreEqual(201942, firstCard.View.HW2Difficulty.DisplayInfo.Id);
        }
    }
}
