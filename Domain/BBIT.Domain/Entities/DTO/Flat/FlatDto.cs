using BBIT.Domain.Entities.DTO.House;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class FlatDto
    {
        public string Id { get; set; }

        public int FlatNumber { get; set; }

        public int Floor { get; set; }

        public int AmountOfRooms { get; set; }

        public int AmountOfTenants { get; set; }

        public double TotalArea { get; set; }

        public double HouseRoom { get; set; }

        public HouseDto House { get; set; }
    }
}
