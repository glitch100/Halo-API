using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetGameVariantTests : BaseHaloAPIServiceTests
    {
        private string validId = "f6de5351-3797-41e9-8053-7fb111a3a1a0";

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetGameVariant(validId), CommonErrorMessages.BadRequest);
        }

        [Test]
        public void KnownInvalid_ThrowException()
        {
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetGameVariant("afaf"), CommonErrorMessages.BadRequest);
        }

        [Test]
        [TestCase("f6de5351-3797-41e9-8053-7fb111a3a1a0")]
        [TestCase("1571fdac-e0b4-4ebc-a73a-6e13001b71d3")]
        public async void Default_DoesNotReturnNull(string id)
        {
            var result = await HaloApiService.GetGameVariant(id);
            Assert.IsNotNull(result);
        }
    }
}