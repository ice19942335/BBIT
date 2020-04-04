using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.Flat
{
    public class UpdateFlatRequestExample : IExamplesProvider<UpdateFlatRequest>
    {
        public UpdateFlatRequest GetExamples()
        {
            return new UpdateFlatRequest
            {
                Id = "624ac106-e3c0-4df3-bca9-03015ea93987",
                FlatNumber = "1",
                Level = 15,
                AmountOfRooms = 5,
                AmountOfResidents = 1,
                TotalArea = 300,
                HouseRoom = 400
            };
        }
    }
}