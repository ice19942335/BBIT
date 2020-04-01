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

        public int AmountOfTenants { get; set; }

        public double TotalArea { get; set; }

        public double HouseRoom { get; set; }

        public virtual House.House House { get; set; }
    }
}
