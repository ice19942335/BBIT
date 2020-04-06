using BBIT.Domain.Entities.DTO.House;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat.Success
{
    public class SuccessFlatCreationResponse
    {
        public string Id { get; set; }

        public string FlatNumber { get; set; }

        public int Level { get; set; }

        public int AmountOfRooms { get; set; }

        public int AmountOfResidents { get; set; }

        public double TotalArea { get; set; }

        public double HouseRoom { get; set; }

        public HouseDto House { get; set; }
    }
}