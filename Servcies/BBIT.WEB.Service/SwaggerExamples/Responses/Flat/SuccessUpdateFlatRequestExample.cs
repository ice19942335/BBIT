using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Responses.Flat
{
    public class SuccessUpdateFlatRequestExample : IExamplesProvider<UpdateFlatRequest>
    {
        public UpdateFlatRequest GetExamples()
        {
            return new UpdateFlatRequest
            {
                Id = "ce71e57d-c18c-47ce-94a5-2363cb187a5a",
                FlatNumber = "1",
                Level = 15,
                AmountOfRooms = 5,
                AmountOfResidents = 0,
                TotalArea = 300,
                HouseRoom = 400
            };
        }
    }
}