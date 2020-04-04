﻿namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.House
{
    public class CreateHouseRequest
    {
        public string HouseNumber { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }
}
