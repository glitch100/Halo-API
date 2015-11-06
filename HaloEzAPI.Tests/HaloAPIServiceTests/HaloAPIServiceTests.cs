using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
