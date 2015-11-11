using System;
using System.Linq;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData
{
    [TestFixture]
    public class GetGameBaseVariantsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetGameBaseVariants());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetGameBaseVariants();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetGameBaseVariants();
            CollectionAssert.AllItemsAreNotNull(result);
        }

        [Test]
        public async void Success_ReturnsKnowGameVariant()
        {
            var result = await HaloApiService.GetGameBaseVariants();
            Assert.True(result.Any(r=>r.Id == new Guid("1e473914-46e4-408d-af26-178fb115de76")));
        }
    }
}