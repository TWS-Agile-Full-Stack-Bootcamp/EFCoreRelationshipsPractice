namespace EFCoreRelationshipsPractice.DTO
{
    public sealed class CreateCompanyRequest
    {
        public string Name { get; set; }
        public CreateProfileRequest Profile { get; set; }
    }

    public class CreateProfileRequest
    {
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}