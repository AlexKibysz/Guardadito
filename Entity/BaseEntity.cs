using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guardadito.Entity
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void SetAuditDates(bool isNew = false)
        {
            if (isNew)
                CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}