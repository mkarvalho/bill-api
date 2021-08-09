using System;
using System.ComponentModel.DataAnnotations;

namespace BillReminder.Shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}
