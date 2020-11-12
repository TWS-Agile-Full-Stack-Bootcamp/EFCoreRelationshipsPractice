﻿using System.ComponentModel.DataAnnotations.Schema;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    [Table("Profile")]
    public class ProfileModel
    {
        public ProfileModel()
        {
        }

        public ProfileModel(ProfileDto profile)
        {
            RegisteredCapital = profile.RegisteredCapital;
            CertId = profile.CertId;
        }

        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }

        public CompanyModel Company { get; set; }

        [ForeignKey("CompanyIdForeignKey")] public int CompanyId { get; set; }
    }
}