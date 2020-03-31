using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.DTO.Base.Interface;

namespace BBIT.Domain.Entities.DTO.Base
{
    public class BaseDto : IBaseDto
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Status { get; set; }

        public bool ItemNotFound { get; set; }

        public bool ServerError { get; set; }
    }
}
