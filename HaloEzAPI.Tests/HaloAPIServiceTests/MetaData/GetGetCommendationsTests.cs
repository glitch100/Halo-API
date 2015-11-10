using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData
{
    [TestFixture]
    public class GetGetCommendationsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetCommendations());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetCommendations();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetCommendations();
            CollectionAssert.AllItemsAreNotNull(result);
        }

        [Test]
        public async void Default_ReturnsKnownMission()
        {
            var result = await HaloApiService.GetCommendations();
            Assert.IsTrue(result.Any(r => r.Id == new Guid("20dc7d74-be8f-4a60-ae4f-15230855cced")));
        }
    }
}