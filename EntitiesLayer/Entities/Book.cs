using BookStore.Shared.Enums;
using EntitiesLayer.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.Entities
{
    public class Book : BaseEntity
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
        public CurrencyType Currency { get; set; }
        [Required]
        public PrintingEditionType Type { get; set; }
    }
}
