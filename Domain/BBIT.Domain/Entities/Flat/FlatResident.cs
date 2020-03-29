using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBIT.Domain.Entities.Flat
{
    [Table("FlatResidents")]
    public class FlatResident
    {
        public Guid FlatId { get; set; }
        public Flat Flat { get; set; }

        public Guid ResidentId { get; set; }
        public Resident.Resident Resident { get; set; }
    }
}