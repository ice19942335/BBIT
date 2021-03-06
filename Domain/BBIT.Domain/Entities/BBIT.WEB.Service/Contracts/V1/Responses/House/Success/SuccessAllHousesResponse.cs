﻿using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.House;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House.Success
{
    public class SuccessAllHousesResponse
    {
        public bool Status { get; set; }

        public IEnumerable<HouseDto> Houses { get; set; }
    }
}
