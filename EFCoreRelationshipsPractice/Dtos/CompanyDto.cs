using System.Collections.Generic;
using System.Linq;
using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }

        public CompanyDto(CompanyModel company)
        {
            Name = company.Name;
            Profile = new ProfileDto(company.Profile);
            Employees = company.Employees?.Select(employee => new EmployeeDto(employee)).ToList();
        }

        public string Name { get; set; }

        public ProfileDto Profile { get; set; }

        public List<EmployeeDto> Employees { get; set; }
    }
}