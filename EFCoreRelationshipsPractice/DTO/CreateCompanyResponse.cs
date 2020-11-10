namespace EFCoreRelationshipsPractice.DTO
{
    public class CreateCompanyResponse
    {
        public string Name { get; set; }
        public CreateProfileResponse Profile { get; set; }
    }

    public class CreateProfileResponse
    {
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}