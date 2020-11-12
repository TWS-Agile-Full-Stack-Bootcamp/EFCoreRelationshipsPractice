using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationshipsPractice.Models
{
    [Table("Profile")]
    public class ProfileModel
    {
        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }

        public CompanyModel Company { get; set; }

        [ForeignKey("CompanyIdForeignKey")]
        public int CompanyId { get; set; }
    }
}