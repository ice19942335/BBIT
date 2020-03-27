using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using BBIT.Domain.Entities.BaseEntity.Interfaces;

namespace BBIT.Domain.Entities.BaseEntity
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
