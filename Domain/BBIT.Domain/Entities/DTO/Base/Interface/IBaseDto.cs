using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.DTO.Base.Interface
{
    public interface IBaseDto
    {
        /// <summary>
        /// List of errors
        /// </summary>
        IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Status of operation
        /// </summary>
        bool Status { get; set; }

        /// <summary>
        /// Shows whatever it's a server error
        /// </summary>
        bool ServerError { get; set; }
    }
}
