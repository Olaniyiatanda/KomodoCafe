using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public class ClaimsRepository
    {
        private Queue<ClaimsProperties> _queueOfClaims = new Queue<ClaimsProperties>();

        //create

    public void AddClaimsToList(ClaimsProperties claims)
        {
            _queueOfClaims.Enqueue(claims);
        }

        //Read 
        public Queue<ClaimsProperties> GetClaimsQueue()
        {
            return _queueOfClaims;
        }

        //Update
        public bool UpdateExitingClaims(int originalclaimId, ClaimsProperties newClaims)
        {
            //Find the claims
            ClaimsProperties oldClaims = GetClaimsbyId(originalclaimId);

            //UPdate the claims 
            if (oldClaims != null)
            {
                oldClaims.ClaimId = newClaims.ClaimId;
                oldClaims.ClaimType = newClaims.ClaimType;
                oldClaims.Description = newClaims.Description;
                oldClaims.ClaimAmount = newClaims.ClaimAmount;
                oldClaims.DateOfIncident = newClaims.DateOfIncident;
                oldClaims.DateOfIncident = newClaims.DateOfIncident;

                return true;

            }
            else
            {
                return false;
            }

        }

        //Delete
        public void RemoveClaimsFromQueue()
        {
            _queueOfClaims.Dequeue();
        
        }
        public ClaimsProperties viewNextClaim()
        {
            return _queueOfClaims.Peek();
        }


        //Helper Method 
        public ClaimsProperties GetClaimsbyId(int claimId)
        {
            foreach (ClaimsProperties claims in _queueOfClaims)
            {
                if(claims.ClaimId == claimId)
                {
                    return claims;
                }
            }
            return null;
        }

    }
}
