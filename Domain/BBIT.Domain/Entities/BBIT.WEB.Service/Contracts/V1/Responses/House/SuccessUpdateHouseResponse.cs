using BBIT.Domain.Entities.DTO.House;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House
{
    public class SuccessUpdateHouseResponse
    {
        public HouseDto House { get; set; }

        public bool Status { get; set; }
    }
}