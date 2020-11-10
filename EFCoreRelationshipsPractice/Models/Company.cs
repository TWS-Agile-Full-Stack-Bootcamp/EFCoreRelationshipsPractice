using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreRelationshipsPractice.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}