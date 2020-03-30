using System;
using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Flat;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant
{
    public class SuccessTenantCreationResponse
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
