using System;
using System.Text;
using BBIT.Domain.Entities.DTO.Flat;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.Flat
{
    public class SuccessFlatByIdResponse
    {
        public bool Status { get; set; }

        public FlatDto Flat { get; set; }
    }
}
