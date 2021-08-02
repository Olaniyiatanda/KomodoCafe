using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public enum TypeOfClaim 
    {
        Car =1,
        Home,
        Theft,
    }



    //Poco
    public class ClaimsProperties
    {
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if (DateOfClaim.Day - DateOfIncident.Day > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        } 
        public TypeOfClaim ClaimType { get; set; }

         

        public ClaimsProperties() { }
        public ClaimsProperties(int claimid,string description,double claimamount,DateTime dateofincident,DateTime dateofclaim, TypeOfClaim ofclaim)
        {
            ClaimId = claimid;
            Description = description;
            ClaimAmount = claimamount; 
            DateOfIncident = dateofclaim;
           
            ClaimType = ofclaim;
            
        }       
    }
}
