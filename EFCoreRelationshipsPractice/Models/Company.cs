using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreRelationshipsPractice.Models
{
    public class Company
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
