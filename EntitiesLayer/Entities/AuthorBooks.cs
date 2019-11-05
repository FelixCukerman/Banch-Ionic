using EntitiesLayer.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.Entities
{
    public class AuthorBooks : BaseEntity
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PrintingEditionId { get; set; }
    }
}
