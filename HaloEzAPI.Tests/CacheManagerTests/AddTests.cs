using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response;
using HaloEzAPI.Model.Response.Stats;
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
            Assert.DoesNotThrow(async () => CacheManager.Add(playerMatches, string.Empty, 0));
        }       
        
        [Test]
        public void ProvideEmptyKey_DoesNotAdd()
        {
            var playerMatches = new PlayerMatches();
            CacheManager.Add(playerMatches, string.Empty, 1);
            Assert.False(CacheManager.Contains(string.Empty));
        }

        [Test]
        [TestCase("valid1")]
        [TestCase("asofafa")]
        [TestCase("asf98af")]
        public void ProvideValidKey_DoesNotAdd(string key)
        {
            var playerMatches = new PlayerMatches();
            CacheManager.Add(playerMatches, key, 1);
            Assert.True(CacheManager.Contains(key));
        }

        [Test]
        public void KeyAlreadyExists_DoesNotAdd()
        {
            var playerMatches = new PlayerMatches() {Start = 115};
            var playerMatchesNotAdd = new PlayerMatches(){Start = 99};
            CacheManager.Add(playerMatches, "IEXIST", 1);
            CacheManager.Add(playerMatchesNotAdd, "IEXIST", 1);
            var obj = CacheManager.Get<PlayerMatches>("IEXIST");
            Assert.AreEqual(obj.Start, 115);
        }
    }
}
