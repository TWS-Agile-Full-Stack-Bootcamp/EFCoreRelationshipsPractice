using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationshipsPractice.Models
{
    [Table("Profile")]
    public class ProfileModel
    {
        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}