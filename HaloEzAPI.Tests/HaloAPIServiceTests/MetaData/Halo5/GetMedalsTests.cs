using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetMedalsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetMedals());
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetMedals();
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Default_ReturnsValidCollection()
        {
            var result = await HaloApiService.GetMedals();
            CollectionAssert.AllItemsAreNotNull(result);
        }
    }
}