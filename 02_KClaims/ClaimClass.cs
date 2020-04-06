using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class ClaimClass
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimClass() { }

        public ClaimClass(int claimID, ClaimType claimType, string description, decimal claimAmmount, DateTime accidentDate, DateTime claimDate, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmmount = claimAmmount;
            DateOfAccident = accidentDate;
            DateOfClaim = claimDate;
            IsValid = isValid;
        }
    }
}
