using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BBIT.Domain.Entities.Flat;

namespace BBIT.Domain.Entities.Resident
{
    [Table("Residents")]
    public class Resident : BaseEntity.BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Flat.Flat Flat { get; set; }

        public ICollection<FlatResident> FlatResidents { get; set; }
    }
}