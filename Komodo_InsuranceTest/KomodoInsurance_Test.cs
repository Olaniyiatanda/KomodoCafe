using Komodo_InsuranceRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_InsuranceTest
{
    [TestClass]
    public class KomodoInsurance_Test
    {
        Dictionary<int, List<string>> _Dictionary = new Dictionary<int, List<string>>();
        private BadgeRepository _badgeRepository = new BadgeRepository();

        [TestInitialize]
        public void Seed()
        {
            BadgeProperties Badge1 = new BadgeProperties(100, new List<string> { "A1", "A2", "A3" }, "alex");
            BadgeProperties Badge2 = new BadgeProperties(200, new List<string> { "B1", "B2", "B3" }, "andrew");
            _badgeRepository.Addbadge(Badge1);
            _badgeRepository.Addbadge(Badge2);
         


        }


        [TestMethod]
        public void AddMethod()
        {
            BadgeProperties Badge3 = new BadgeProperties(400, new List<string> { "C1", "C2", "C33" }, "alex");
            _badgeRepository.Addbadge(Badge3);
            var badges = _badgeRepository.GetDictionary();
            int actual = badges.Count;
            int expected = 3;
            Assert.AreEqual(actual, expected);


        }
      

    }
}
