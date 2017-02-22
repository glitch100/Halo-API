using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Caching;
using HaloEzAPI.Limits;
using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests
{
    public class BaseHaloAPIServiceTests
    {
        protected HaloAPIService HaloApiService;

        [SetUp]
        public void SetUp()
        {
            HaloApiService = new HaloAPIService("OMITTED_INCLUDE_YOUR_OWN");
            SingletonCacheManager.Instance.RemoveAll();
        }

        [Test]
        public void Default_InvalidAPIKey_Unauthorized()
        {
            RequestRateHttpClient.SetAPIToken("INVALID");
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetMatchesForPlayer("a", GameMode.Arena),
                CommonErrorMessages.AccessDenied);
        }
    }
}
