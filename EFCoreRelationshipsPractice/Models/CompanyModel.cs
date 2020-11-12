using System.Collections.Generic;
using System.Linq;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    public class CompanyModel
    {
        public CompanyModel()
        {
        }

        public CompanyModel(CompanyDto company)
        {
            Name = company.Name;
            Profile = new ProfileModel(company.Profile);
            Employees = company.Employees?.Select(employee => { return new EmployeeModel(employee); }).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileModel Profile { get; set; }

        public virtual IList<EmployeeModel> Employees { get; set; }
    }
}