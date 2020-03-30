using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Resident;

namespace Services.Resident
{
    public class ResidentService : IResidentService
    {
        private readonly IResidentService _residentService;

        public ResidentService(IResidentService residentService)
        {
            _residentService = residentService;
        }
    }
}
