using HaloEzAPI.Caching;
using HaloEzAPI.Model.Response;
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
            Assert.DoesNotThrow(async () => CacheManager.Get<PlayerMatches>(string.Empty));
        }

        [Test]
        public void NonExistentEntry_ReturnsNull()
        {
            Assert.IsNull(CacheManager.Get<PlayerMatches>("TEST"));
        }

        [Test]
        public void EntryExists_ReturnsObject()
        {
            var playerMatches = new PlayerMatches() {Count = 2, IsTeamGame = true, ResultCount = 10, Start = 2};
            CacheManager.Add(playerMatches,"VALID",1);
            var obj = CacheManager.Get<PlayerMatches>("VALID");
            Assert.IsTrue(PlayerMatchesEqual(playerMatches,obj));
        }

        [Test]
        public void RetrieveWrongType_ReturnsNull()
        {
            var playerMatches = new PlayerMatches() { Count = 2, IsTeamGame = true, ResultCount = 10, Start = 2 };
            CacheManager.Add(playerMatches, "VALID", 1);
            var obj = CacheManager.Get<CustomGameServiceRecord>("VALID");
            Assert.IsNull(obj);
        }

        private bool PlayerMatchesEqual(PlayerMatches a, PlayerMatches b)
        {
            return (a.Start == b.Start && a.IsTeamGame == b.IsTeamGame && a.Count == b.Count &&
                    a.ResultCount == b.ResultCount);
        }
    }
}