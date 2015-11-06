using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
