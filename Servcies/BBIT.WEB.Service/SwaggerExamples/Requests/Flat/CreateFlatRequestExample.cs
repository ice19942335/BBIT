using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat;
using BBIT.Domain.Entities.DTO.House;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.Flat
{
    public class CreateFlatRequestExample : IExamplesProvider<CreateFlatRequest>
    {
        public CreateFlatRequest GetExamples()
        {
            return new CreateFlatRequest
            {
                HouseId = "40e5ba94-57ee-4f1b-980d-0b9f9273e008",
                FlatNumber = "1",
                Floor = 15,
                AmountOfRooms = 5,
                TotalArea = 300,
                HouseRoom = 400
            };
        }
    }
}
