using HaloEzAPI.Limits;
using HaloEzAPI.Model.Response.Error;
using HaloEzAPI.Tests.HaloAPIServiceTests;
using NUnit.Framework;

namespace HaloEzAPI.Tests.RequestRateHttpClientTests
{
    [TestFixture]
    public class SetAPITokenTests : BaseHaloAPIServiceTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Default_DoesNotThrow(string token)
        {
            Assert.DoesNotThrow(() => RequestRateHttpClient.SetAPIToken(token)); 
        }

        [Test]
        [TestCase("INVALID")]
        public void ChangeTokenToInvalid_ThrowAccessDenied(string token)
        {
            RequestRateHttpClient.SetAPIToken(token);
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetArenaServiceRecords(new[] {"Glitch100"}),CommonErrorMessages.AccessDenied);
        }
    }
}
