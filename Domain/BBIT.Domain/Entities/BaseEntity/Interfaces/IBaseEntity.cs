using System;
using System.Collections.Generic;
using System.Text;

namespace BBIT.Domain.Entities.BaseEntity.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
