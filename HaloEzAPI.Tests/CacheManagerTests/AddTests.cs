using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response.Stats.Halo5;
using HaloEzAPI.Tests.HaloAPIServiceTests;
using NUnit.Framework;

namespace HaloEzAPI.Tests.CacheManagerTests
{
    [TestFixture]
    public class AddTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrow()
        {
            var playerMatches = new PlayerMatches();
            Assert.DoesNotThrow(async () => SingletonCacheManager.Instance.Add(playerMatches, string.Empty, 0));
        }       
        
        [Test]
        public void ProvideEmptyKey_DoesNotAdd()
        {
            var playerMatches = new PlayerMatches();
            SingletonCacheManager.Instance.Add(playerMatches, string.Empty, 1);
            Assert.False(SingletonCacheManager.Instance.Contains(string.Empty));
        }

        [Test]
        [TestCase("valid1")]
        [TestCase("asofafa")]
        [TestCase("asf98af")]
        public void ProvideValidKey_DoesNotAdd(string key)
        {
            var playerMatches = new PlayerMatches();
            SingletonCacheManager.Instance.Add(playerMatches, key, 1);
            Assert.True(SingletonCacheManager.Instance.Contains(key));
        }

        [Test]
        public void KeyAlreadyExists_DoesNotAdd()
        {
            var playerMatches = new PlayerMatches() {Start = 115};
            var playerMatchesNotAdd = new PlayerMatches(){Start = 99};
            SingletonCacheManager.Instance.Add(playerMatches, "IEXIST", 1);
            SingletonCacheManager.Instance.Add(playerMatchesNotAdd, "IEXIST", 1);
            var obj = SingletonCacheManager.Instance.Get<PlayerMatches>("IEXIST");
            Assert.AreEqual(obj.Start, 115);
        }
    }
}
