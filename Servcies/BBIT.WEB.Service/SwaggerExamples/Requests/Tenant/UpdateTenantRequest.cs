using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.Domain.Entities.DTO.Flat;
using BBIT.Domain.Entities.DTO.Tenant;

namespace BBIT.WEB.Service.SwaggerExamples.Requests.Tenant
{
    public class UpdateTenantRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public FlatDto Flat { get; set; }
    }
}
