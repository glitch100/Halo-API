using System;
using HaloEzAPI.Model.Response.Error;
using NUnit.Framework;

namespace HaloEzAPI.Tests.HaloAPIServiceTests.MetaData
{
    [TestFixture]
    public class GetRequisitionTests : BaseHaloAPIServiceTests
    {
        private Guid validId = new Guid("e4f549b2-90af-4dab-b2bc-11a46ea44103");

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(async () => await HaloApiService.GetRequisition(validId), CommonErrorMessages.BadRequest);
        }

        [Test]
        public void KnownInvalid_ThrowException()
        {
            Assert.Throws<HaloAPIException>(async () => await HaloApiService.GetRequisition(Guid.Empty), CommonErrorMessages.BadRequest);
        }

        [Test]
        public async void Default_DoesNotReturnNull()
        {
            var result = await HaloApiService.GetRequisition(validId);
            Assert.IsNotNull(result);
        }
    }
}