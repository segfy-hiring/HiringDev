using System;

namespace YoutubeTree.Core
{    
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(Entity entity)
        {
            if (ReferenceEquals(this, entity)) return true;
            if (entity is null) return false;

            return Id.Equals(entity.Id);
        }

        public override bool Equals(object entity)
        {
            return Equals(entity as Entity);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
