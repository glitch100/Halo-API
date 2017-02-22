using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response.Stats.Halo5;
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
            Assert.DoesNotThrow(async () => SingletonCacheManager.Instance.Contains(string.Empty));
        }

        [Test]
        public void ProvideInvalidKey_ReturnsFalse()
        {
            Assert.IsFalse(SingletonCacheManager.Instance.Contains(string.Empty));
        }

        [Test]
        public void ProvideValidKeyDoesntExist_ReturnsFalse()
        {
            Assert.IsFalse(SingletonCacheManager.Instance.Contains("VALID"));
        }

        [Test]
        public void ProvideValidKeyDoesExist_ReturnsTrue()
        {
            var playerMatches = new PlayerMatches();
            SingletonCacheManager.Instance.Add(playerMatches,"VALID",1);
            Assert.IsTrue(SingletonCacheManager.Instance.Contains("VALID"));
        }
    }
}