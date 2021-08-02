using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo_ClaimsTest
{
    [TestClass]
    public class ClaimsRepositoryTest
    {
        private ClaimsRepository _repo= new ClaimsRepository();
        private ClaimsProperties _claims;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _claims = new ClaimsProperties(5, "car accident on 465", 500, DateTime.Parse("04/01/2018"), DateTime.Parse("03/24/2018"), TypeOfClaim.Theft);
            _repo.AddClaimsToList(_claims);
        }

        //Add Method
        [TestMethod]
        public void AddClaimsToList()
        {
            //Arrange -- Setting up the playing field 
            ClaimsProperties claims = new ClaimsProperties
            {
                ClaimAmount = 400,
                ClaimId = 1,
                ClaimType = TypeOfClaim.Car,
                DateOfClaim = DateTime.Parse("4/27/2018"),
                DateOfIncident = DateTime.Parse("4/25/2018"),
                Description = "Car accident on 465"
            };
          
            ClaimsRepository repository = new ClaimsRepository();

            //Act
            repository.AddClaimsToList(claims);

            ClaimsProperties actual = repository.GetClaimsbyId(1);
            Assert.IsNotNull(actual);
            


            

            //Assert--Use the assert class to verify the expected outcome.
            
         
            


        }
        // Update
        [TestMethod]
        public void UpadateExitingClaims_ShouldReturnTrue()
        {
            //Arrange
            //TestInitilize
            ClaimsProperties newClaims = new ClaimsProperties(3, "car accident on 465", 500, DateTime.Parse("04/01/2018"), DateTime.Parse("03/24/2018"), TypeOfClaim.Car);
            //Act
            bool updateResult = _repo.UpdateExitingClaims(5,newClaims);
            //Assert
            Assert.IsTrue(updateResult); 
        }


        [TestMethod]
        public void Deletemethod()
        {
            _repo.RemoveClaimsFromQueue();
            Assert.IsNull(_repo.GetClaimsbyId(5));

        }


        [TestMethod]
        public void TestReadMethod()
        {
            var listofClaim = _repo.GetClaimsQueue();
            Assert.IsNotNull(listofClaim);
        }


        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(3, false)]
        public void UpdateExitingClaims_ShouldMatchGivenBool(int originalClaimId, bool shouldUpdate) 
        {
            //Arrange
            //TestInitilize
            ClaimsProperties newClaims = new ClaimsProperties();
            //Act
            bool updateResult = _repo.UpdateExitingClaims(originalClaimId, newClaims);
            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }
         
    }
}
 