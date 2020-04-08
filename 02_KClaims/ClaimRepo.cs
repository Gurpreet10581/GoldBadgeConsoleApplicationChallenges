using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims
{
    public class ClaimRepo
    {
         Queue<ClaimContent> queueList = new Queue<ClaimContent>();
      
        public Queue<ClaimContent> GetListOfClaims()
        {
            return queueList;
        }

        public bool EnterNewClaim(ClaimContent content)
        {
            int claimCount = queueList.Count;
            queueList.Enqueue(content);
            bool wasAdded = (queueList.Count > claimCount) ? true : false;
            return wasAdded;
        }
        public ClaimContent OpenNextClaim()
        {
           return queueList.Dequeue();

        }
        public bool IsValid(ClaimContent claim)
        {
            TimeSpan timeFrame = claim.DateOfClaim.Subtract(claim.DateOfAccident);

            if (timeFrame.Days <= 30)
            {
                return true;
            }
            return false;
        }
       
        
    }
}
