using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace activity_scheduling.domain.Entities
{
    public class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }

        public Entity()
        {}
        public Entity(Guid id)
        {
            Id = id;
        }

        public bool Equals(Entity? other)=>
            other != null && Id == other.Id;
    }
}