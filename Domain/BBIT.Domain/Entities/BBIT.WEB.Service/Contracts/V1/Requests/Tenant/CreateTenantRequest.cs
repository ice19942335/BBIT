using System;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant
{
    public class CreateTenantRequest
    {
        public string FlatId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
