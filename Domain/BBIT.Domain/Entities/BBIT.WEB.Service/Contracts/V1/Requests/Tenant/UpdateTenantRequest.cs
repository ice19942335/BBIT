using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BBIT.Domain.Entities.DTO.Flat;

namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts.V1.Requests.Tenant
{
    public class UpdateTenantRequest
    {
        public string NewFlatId { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        [RegularExpression("^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$", ErrorMessage = "Date of birth format is: mm/dd/yyyy or m/d/yyyy")]
        public string DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
