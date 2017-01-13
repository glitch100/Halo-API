using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response;
using HaloEzAPI.Model.Response.Stats;
using HaloEzAPI.Tests.HaloAPIServiceTests;
using NUnit.Framework;

namespace HaloEzAPI.Tests.CacheManagerTests
{
    [TestFixture]
    public class RemoveTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrow()
        {
            Assert.DoesNotThrow(async () => SingletonCacheManager.Instance.Remove(string.Empty));
        }

        [Test]
        public void ProvideValidKey_RemovesEntry()
        {
            var playerMatches = new PlayerMatches();
            SingletonCacheManager.Instance.Add(playerMatches,"VALID",1);
            SingletonCacheManager.Instance.Remove("VALID");
            var obj = SingletonCacheManager.Instance.Get<PlayerMatches>("VALID");
            Assert.IsNull(obj);
        }
    }    
    
    [TestFixture]
    public class RemoveAllTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrow()
        {
            Assert.DoesNotThrow(async () => SingletonCacheManager.Instance.RemoveAll());
        }

        [Test]
        public void ProvideValidKey_RemovesEntry()
        {
            var playerMatches = new PlayerMatches();
            var playerMatches1 = new PlayerMatches();
            var playerMatches2 = new PlayerMatches();
            SingletonCacheManager.Instance.Add(playerMatches,"VALID",1);
            SingletonCacheManager.Instance.Add(playerMatches1, "VALID1", 1);
            SingletonCacheManager.Instance.Add(playerMatches2, "VALID2", 1);
            SingletonCacheManager.Instance.RemoveAll();
            var obj = SingletonCacheManager.Instance.Get<PlayerMatches>("VALID");
            var obj1 = SingletonCacheManager.Instance.Get<PlayerMatches>("VALID1");
            var obj2 = SingletonCacheManager.Instance.Get<PlayerMatches>("VALID2");
            Assert.IsNull(obj);
            Assert.IsNull(obj1);
            Assert.IsNull(obj2);
        }
    }
}