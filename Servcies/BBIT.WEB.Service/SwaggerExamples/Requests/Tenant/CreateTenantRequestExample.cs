using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant;
using Swashbuckle.AspNetCore.Filters;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.Tenant
{
    public class CreateTenantRequestExample : IExamplesProvider<CreateTenantRequest>
    {
        public CreateTenantRequest GetExamples()
        {
            return new CreateTenantRequest
            {
                FlatId = "4644e41b-c19e-4f24-96f3-013103030c5a",
                Name = "Name",
                Surname = "Surname",
                PersonalCode = "12345",
                DateOfBirth = DateTime.Today,
                PhoneNumber = "+37112345678",
                Email = "email@mail.com"
            };
        }
    }
}
