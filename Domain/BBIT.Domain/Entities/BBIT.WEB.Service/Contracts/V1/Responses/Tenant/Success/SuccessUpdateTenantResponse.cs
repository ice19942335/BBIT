using BBIT.Domain.Entities.DTO.Tenant;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Tenant.Success
{
    public class SuccessUpdateTenantResponse
    {
        public bool Status { get; set; }

        public TenantDto Tenant { get; set; }
    }
}