using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims
{
    public class ClaimRepo
    {
        private readonly Queue<ClaimClass> _queueOfClaims = new Queue<ClaimClass>();

        private int claimNumber = 0;
        public void AddNewClaim(ClaimType claimType, string description, decimal claimAmmount, DateTime accidentDate, DateTime claimDate)
        {
            claimNumber = ++;

            bool isValid = false;
            if (((accidentDate - claimDate).TotalDays) < 30)
                isValid = true;

            ClaimClass claim = new ClaimClass(claimNumber, claimType, description, claimAmmount, accidentDate, claimDate, isValid);
            _queueOfClaims.Enqueue(claim);
        }
        public Queue<ClaimClass> GetClaims()
        {
            return _queueOfClaims;
        }
    }
}
