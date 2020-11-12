using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public EmployeeDto(EmployeeModel employee)
        {
            Name = employee.Name;
            Age = employee.Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}