﻿using System.Collections.Generic;
using BBIT.Domain.Entities.DTO.Base;
using BBIT.Domain.Entities.DTO.House;

namespace BBIT.Domain.Entities.DTO.Flat
{
    public class CreateFlatDto : BaseDto
    {
        public string HouseId { get; set; }

        public string Id { get; set; }

        public string FlatNumber { get; set; }

        public int Floor { get; set; }

        public int AmountOfRooms { get; set; }

        public int AmountOfTenants { get; set; }

        public double TotalArea { get; set; }

        public double HouseRoom { get; set; }

        public HouseDto House { get; set; }
    }
}