using System.ComponentModel.DataAnnotations.Schema;

namespace BBIT.Domain.Entities.House
{
    [Table("Houses")]
    public class House : BaseEntity.BaseEntity
    {
        public string HouseNumber { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }
}