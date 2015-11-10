using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response;
using HaloEzAPI.Model.Response.Stats;
using HaloEzAPI.Tests.HaloAPIServiceTests;
using NUnit.Framework;

namespace HaloEzAPI.Tests.CacheManagerTests
{
    [TestFixture]
    public class ContainsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrow()
        {
            Assert.DoesNotThrow(async () => CacheManager.Contains(string.Empty));
        }

        [Test]
        public void ProvideInvalidKey_ReturnsFalse()
        {
            Assert.IsFalse(CacheManager.Contains(string.Empty));
        }

        [Test]
        public void ProvideValidKeyDoesntExist_ReturnsFalse()
        {
            Assert.IsFalse(CacheManager.Contains("VALID"));
        }

        [Test]
        public void ProvideValidKeyDoesExist_ReturnsTrue()
        {
            var playerMatches = new PlayerMatches();
            CacheManager.Add(playerMatches,"VALID",1);
            Assert.IsTrue(CacheManager.Contains("VALID"));
        }
    }
}