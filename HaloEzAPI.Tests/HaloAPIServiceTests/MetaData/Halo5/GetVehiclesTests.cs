using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetVehiclesTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetVehicles());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetVehicles();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetVehicles();
            CollectionAssert.AllItemsAreNotNull(result);
        }
    }
}