using EntitiesLayer.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLayer.Entities
{
    public class AuthorBooks : BaseEntity
    {
        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int? BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}