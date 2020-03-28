﻿namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Responses.House
{
    public class SuccessHouseCreationResponse
    {
        public string Id { get; set; }

        public int HouseNumber { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }
}