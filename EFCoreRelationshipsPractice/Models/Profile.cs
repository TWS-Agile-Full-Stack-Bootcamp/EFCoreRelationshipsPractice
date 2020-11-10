using System.ComponentModel.DataAnnotations;

namespace EFCoreRelationshipsPractice.Models
{
    public class Profile
    {
        [Key]
        public long Id { get; set; }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}