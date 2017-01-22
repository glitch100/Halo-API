using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData
{
    [TestFixture]
    public class GetCSRDesignationsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetCSRDesignations());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetCSRDesignations();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetCSRDesignations();
            CollectionAssert.AllItemsAreNotNull(result);
        }
    }
}