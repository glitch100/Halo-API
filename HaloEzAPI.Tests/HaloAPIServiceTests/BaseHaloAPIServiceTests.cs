using HaloEzAPI.Abstraction.Enum;
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
            HaloApiService = new HaloAPIService("562fb69c76a04a6fad4acd83e564ea11");
            CacheManager.RemoveAll();
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
