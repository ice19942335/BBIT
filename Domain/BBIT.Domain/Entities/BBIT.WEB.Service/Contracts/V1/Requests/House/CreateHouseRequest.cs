using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBIT.WEB.Service.Contracts.V1.Requests.House
{
    public class CreateHouseRequest
    {
        public int HouseNumber { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }
}
