using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response.Stats.Halo5;
using HaloEzAPI.Model.Response.Stats.Halo5.CustomGame;
using HaloEzAPI.Tests.HaloAPIServiceTests;
using NUnit.Framework;

namespace HaloEzAPI.Tests.CacheManagerTests
{
    [TestFixture]
    public class GetTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrow()
        {
            Assert.DoesNotThrow(async () => SingletonCacheManager.Instance.Get<PlayerMatches>(string.Empty));
        }

        [Test]
        public void NonExistentEntry_ReturnsNull()
        {
            Assert.IsNull(SingletonCacheManager.Instance.Get<PlayerMatches>("TEST"));
        }

        [Test]
        public void EntryExists_ReturnsObject()
        {
            var playerMatches = new PlayerMatches() {Count = 2, IsTeamGame = true, ResultCount = 10, Start = 2};
            SingletonCacheManager.Instance.Add(playerMatches,"VALID",1);
            var obj = SingletonCacheManager.Instance.Get<PlayerMatches>("VALID");
            Assert.IsTrue(PlayerMatchesEqual(playerMatches,obj));
        }

        [Test]
        public void RetrieveWrongType_ReturnsNull()
        {
            var playerMatches = new PlayerMatches() { Count = 2, IsTeamGame = true, ResultCount = 10, Start = 2 };
            SingletonCacheManager.Instance.Add(playerMatches, "VALID", 1);
            var obj = SingletonCacheManager.Instance.Get<CustomGameServiceRecord>("VALID");
            Assert.IsNull(obj);
        }

        private bool PlayerMatchesEqual(PlayerMatches a, PlayerMatches b)
        {
            return (a.Start == b.Start && a.IsTeamGame == b.IsTeamGame && a.Count == b.Count &&
                    a.ResultCount == b.ResultCount);
        }
    }
}