using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BBIT.Domain.Entities.House
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

        public House House { get; set; }
    }
}
