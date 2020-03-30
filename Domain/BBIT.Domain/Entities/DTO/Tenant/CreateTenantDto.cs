using System.Collections.Generic;

namespace BBIT.Domain.Entities.DTO.Tenant
{
    public class CreateTenantDto
    {
        public string FlatId { get; set; }

        public TenantDto Tenant { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }

        public bool ServerError { get; set; }
    }
}