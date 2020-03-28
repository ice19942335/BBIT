using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.DTO.House
{
    public class HouseDto
    {
        public string Id { get; set; }

        public int HouseNumber { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }
}
