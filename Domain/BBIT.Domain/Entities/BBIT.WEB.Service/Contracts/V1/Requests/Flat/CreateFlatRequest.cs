using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.House;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Flat
{
    public class CreateFlatRequest
    {
        public int FlatNumber { get; set; }

        public int Floor { get; set; }

        public int AmountOfRooms { get; set; }


        public double TotalArea { get; set; }

        public double HouseRoom { get; set; }

        public HouseDto House { get; set; }
    }
}
