using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Profile
{

    [TestFixture]
    public class GetProfileEmblemTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetProfileEmblem("Test"));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetProfileEmblem("Glitch100");
            Assert.IsNotNull(result);
        }
    }
}
