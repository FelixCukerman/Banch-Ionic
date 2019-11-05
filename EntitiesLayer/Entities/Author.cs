using EntitiesLayer.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
