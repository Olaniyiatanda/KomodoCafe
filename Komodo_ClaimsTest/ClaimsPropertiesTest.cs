using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_ClaimsTest
{
    [TestClass]
    public class ClaimsPropertiesTest
    {
        [TestMethod]
        public void SetClaimId_ShouldSetCorrectInt()
        {
            ClaimsProperties claims = new ClaimsProperties();

            claims.ClaimId = 2;
            int expected = 2;
            int actual = claims.ClaimId;

            Assert.AreEqual(expected, actual);
        }
    }
}

