using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.House;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat
{
    public class UpdateFlatRequest
    {
        public string Id { get; set; }

        public string FlatNumber { get; set; }

        public int Level { get; set; }

        public int AmountOfRooms { get; set; }

        public int AmountOfResidents { get; set; }

        public double TotalArea { get; set; }

        public double HouseRoom { get; set; }
    }
}
