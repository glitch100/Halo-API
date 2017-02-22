using HaloEzAPI.Model.Request;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.UGC.Halo5
{
    public class GetGameVariantTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetUGCGameVariant("ARC GuiltySpark", "17ce1aba-376b-470c-bce3-f90bfbac41f9"));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetUGCGameVariant("ARC GuiltySpark", "17ce1aba-376b-470c-bce3-f90bfbac41f9");
            Assert.IsNotNull(result);
        }

        [Test]
        public async void ProvideValidDetails_ReturnsKnownProperties()
        {
            const string gamerTag = "ARC GuiltySpark";
            var result = await HaloApiService.GetUGCGameVariant(gamerTag, "17ce1aba-376b-470c-bce3-f90bfbac41f9");
            Assert.AreEqual(gamerTag, result.Identity.Owner);
            Assert.IsNotNull(result);
        }
    }    
    
    public class GetMapVariantsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetUGCMapVariants("ARC GuiltySpark", 0, 10, Sort.Modified, Order.Asc));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetUGCMapVariants("ARC GuiltySpark", 0, 10, Sort.Modified, Order.Asc);
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Request10_ResultCountIs10()
        {
            var result = await HaloApiService.GetUGCMapVariants("ARC GuiltySpark", 0, 10, Sort.Modified, Order.Asc);
            Assert.True(result.Count == 10);
        }
    }    
    
    public class GetGameVariantsTests : BaseHaloAPIServiceTests
    {
        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetUGCMapVariants("ARC GuiltySpark", 0, 10, Sort.Modified, Order.Asc));
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetUGCMapVariants("ARC GuiltySpark", 0, 10, Sort.Modified, Order.Asc);
            Assert.IsNotNull(result);
        }

        [Test]
        public async void Request10_ResultCountIs10()
        {
            var result = await HaloApiService.GetUGCMapVariants("ARC GuiltySpark", 0, 10, Sort.Modified, Order.Asc);
            Assert.True(result.Count == 10);
        }
    }
}