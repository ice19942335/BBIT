using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBIT.Domain.Entities.Flat
{
    [Table("Flats")]
    public class Flat : BaseEntity.BaseEntity
    {
        public int FlatNumber { get; set; }

        public int Floor { get; set; }

        public int AmountOfRooms { get; set; }

        public int AmountOfResidents { get; set; }

        public double TotalArea { get; set; }

        public double HouseRoom { get; set; }

        public House.House House { get; set; }

        public ICollection<FlatResident> FlatResidents { get; set; }
    }
}
