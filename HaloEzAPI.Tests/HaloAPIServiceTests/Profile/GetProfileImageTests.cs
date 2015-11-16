using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.Profile
{
    [TestFixture]
    public class GetProfileImageTests : BaseHaloAPIServiceTests
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

        [Test]
        public async void Success_ReturnsDefaultWidth()
        {
            var result = await HaloApiService.GetProfileEmblem("Glitch100");
            Assert.AreEqual(256, result.Width);
        }
    }
}