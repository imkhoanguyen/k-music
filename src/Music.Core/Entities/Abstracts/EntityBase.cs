using System.ComponentModel.DataAnnotations;

namespace Music.Core.Entities.Abstracts
{
    public abstract class EntityBase<T>
    {
        [Required]
        public T Id { get ; set ; }
    }
}
