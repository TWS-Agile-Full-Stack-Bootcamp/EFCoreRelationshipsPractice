namespace EFCoreRelationshipsPractice.DTO
{
    public sealed class ListCompanyResponse
    {
        public string Name { get; set; }
        public ListProfileResponse Profile { get; set; }
    }

    public class ListProfileResponse
    {
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}