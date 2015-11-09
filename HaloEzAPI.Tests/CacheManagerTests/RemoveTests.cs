using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response;
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
            Assert.DoesNotThrow(async () => CacheManager.Remove(string.Empty));
        }

        [Test]
        public void ProvideValidKey_RemovesEntry()
        {
            var playerMatches = new PlayerMatches();
            CacheManager.Add(playerMatches,"VALID",1);
            CacheManager.Remove("VALID");
            var obj = CacheManager.Get<PlayerMatches>("VALID");
            Assert.IsNull(obj);
        }
    }    
    
    [TestFixture]
    public class RemoveAllTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrow()
        {
            Assert.DoesNotThrow(async () => CacheManager.RemoveAll());
        }

        [Test]
        public void ProvideValidKey_RemovesEntry()
        {
            var playerMatches = new PlayerMatches();
            var playerMatches1 = new PlayerMatches();
            var playerMatches2 = new PlayerMatches();
            CacheManager.Add(playerMatches,"VALID",1);
            CacheManager.Add(playerMatches1, "VALID1", 1);
            CacheManager.Add(playerMatches2, "VALID2", 1);
            CacheManager.RemoveAll();
            var obj = CacheManager.Get<PlayerMatches>("VALID");
            var obj1 = CacheManager.Get<PlayerMatches>("VALID1");
            var obj2 = CacheManager.Get<PlayerMatches>("VALID2");
            Assert.IsNull(obj);
            Assert.IsNull(obj1);
            Assert.IsNull(obj2);
        }
    }
}