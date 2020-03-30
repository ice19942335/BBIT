using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBIT.Domain.Entities.Tenant
{
    [Table("Tenants")]
    public class Tenant : BaseEntity.BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Flat.Flat Flat { get; set; }
    }
}