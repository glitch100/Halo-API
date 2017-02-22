using System;
using HaloEzAPI.Limits;
using HaloEzAPI.Tests.HaloAPIServiceTests;
using NUnit.Framework;

namespace HaloEzAPI.Tests.RequestRateHttpClientTests
{
    public class GetRequestTests : BaseHaloAPIServiceTests
    {
        private string DummyMatchesForPlayerEndpoint = "https://www.haloapi.com/stats/h5/players/Glitch100/matches";

        [Test]
        public void Default_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => RequestRateHttpClient.GetRequest(new Uri(DummyMatchesForPlayerEndpoint)));
        }

        [Test]
        public void MoreThanLimitSent_DoesNotThrow()
        {
            for (int i = 0; i < 15; i++)
            {
                Assert.DoesNotThrow(() => RequestRateHttpClient.GetRequest(new Uri(DummyMatchesForPlayerEndpoint)));
            }
        }

    }
}