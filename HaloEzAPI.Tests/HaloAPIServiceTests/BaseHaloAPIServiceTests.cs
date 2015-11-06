using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests
{
    [TestFixture]
    public class BaseHaloAPIServiceTests
    {
        protected HaloAPIService HaloApiService;

        [SetUp]
        public void SetUp()
        {
            HaloApiService = new HaloAPIService("YOURTOKENHERE");
        }
    }
}
