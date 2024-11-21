using System.Collections.Generic;

namespace CMCS4
{
    public static class ClaimRepository
    {
        public static List<Claim> Claims = new List<Claim>();

        public static void AddClaim(Claim claim)
        {
            Claims.Add(claim);
        }

        public static List<Claim> GetPendingClaims()
        {
            return Claims.FindAll(c => c.Status == "Pending");
        }

        public static List<Claim> GetClaimsByLecturer(string lecturerName)
        {
            return Claims.FindAll(c => c.LecturerName == lecturerName);
        }
    }
}
