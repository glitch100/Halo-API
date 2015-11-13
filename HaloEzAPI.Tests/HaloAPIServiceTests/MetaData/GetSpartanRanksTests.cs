using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData
{
    [TestFixture]
    public class GetSpartanRanksTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetSpartanRanks());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetSpartanRanks();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetSpartanRanks();
            CollectionAssert.AllItemsAreNotNull(result);
        }

        [Test]
        public async void Success_ContainsKnownRank()
        {
            var result = await HaloApiService.GetSpartanRanks();
            Assert.IsTrue(result.Any(r => r.ContentId == new Guid("5f6e9682-b192-4aa5-9516-883d23e31aec")));
        }

        [Test]
        public async void ReturnedObject_ContainsCorrectXp()
        {
            var result = await HaloApiService.GetSpartanRanks();
            var known = result.First(r => r.ContentId == new Guid("5f6e9682-b192-4aa5-9516-883d23e31aec"));
            Assert.AreEqual(known.StartXP, 10700);
        }
    }
}