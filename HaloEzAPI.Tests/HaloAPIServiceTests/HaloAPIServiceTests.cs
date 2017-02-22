using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests
{
    [TestFixture]
    public class HaloAPIServiceTests
    {
        private HaloAPIService _haloApiService;

        [Test]
        public void Default_DoesntThrowException()
        {
            Assert.DoesNotThrow(() =>  _haloApiService = new HaloAPIService("TOKEN"));   
        }
    }
}
