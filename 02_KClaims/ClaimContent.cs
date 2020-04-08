using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims
{
    public enum ClaimType { Car = 1, Home, Theft }

    public class ClaimContent
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimContent() { }

        public ClaimContent(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime accidentDate, DateTime claimDate, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfAccident = accidentDate;
            DateOfClaim = claimDate;
            IsValid = isValid;
        }
    }
}
