using System.Runtime.ConstrainedExecution;
using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public ProfileDto(ProfileModel profile)
        {
            RegisteredCapital = profile.RegisteredCapital;
            CertId = profile.CertId;
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}