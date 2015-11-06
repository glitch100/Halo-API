using HaloEzAPI.Abstraction.Enum;
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
            HaloApiService = new HaloAPIService("37c86fbf0f4247b980143cabb77b4a42");
        }

        [Test]
        public void Default_InvalidAPIKey_Unauthorized()
        {
            HaloApiService = new HaloAPIService("INVALID");
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetMatchesForPlayer("a", GameMode.Arena),
                CommonErrorMessages.AccessDenied);
        }
    }
}
