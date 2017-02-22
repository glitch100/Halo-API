using System;
using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData.Halo5
{
    [TestFixture]
    public class GetRequisitionPackTests : BaseHaloAPIServiceTests
    {
        private Guid validId = new Guid("3a1614d9-20a4-4817-a189-88cb781e9152");

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetRequisitionPack(validId), CommonErrorMessages.BadRequest);
        }

        [Test]
        public void KnownInvalid_ThrowException()
        {
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetRequisitionPack(Guid.Empty), CommonErrorMessages.BadRequest);
        }

        [Test]
        [TestCase("3a1614d9-20a4-4817-a189-88cb781e9152")]
        [TestCase("3ce05b60-a118-4ad1-9617-bc04f64ac4d8")]
        [TestCase("5f96269a-58f8-473e-9897-42a4deb1bf09")] 
        public async void Default_DoesNotReturnNull(string id)
        {
            var result = await HaloApiService.GetRequisitionPack(new Guid(id));
            Assert.IsNotNull(result);
        }
    }
}