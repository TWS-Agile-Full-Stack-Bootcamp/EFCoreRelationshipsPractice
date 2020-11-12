namespace EFCoreRelationshipsPractice.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileModel Profile { get; set; }
    }
}