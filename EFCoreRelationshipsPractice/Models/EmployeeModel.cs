using System.ComponentModel.DataAnnotations.Schema;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        public EmployeeModel()
        {
        }

        public EmployeeModel(EmployeeDto employee)
        {
            Name = employee.Name;
            Age = employee.Age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public CompanyModel Company { get; set; }

        [ForeignKey("CompanyIdForeignKey")] public int CompanyId { get; set; }
    }
}