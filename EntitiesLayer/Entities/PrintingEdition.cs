using EntitiesLayer.Abstractions;
using EntitiesLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.Entities
{
    public class PrintingEdition : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool IsRemoved { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public PrintingEditionType Type { get; set; }
    }
}
