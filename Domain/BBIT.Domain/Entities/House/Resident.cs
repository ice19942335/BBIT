using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBIT.Domain.Entities.House
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

        public Flat Flat { get; set; }
    }
}