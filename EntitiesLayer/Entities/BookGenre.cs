using EntitiesLayer.Abstractions;
using EntitiesLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.EL.Entities
{
    public class BookGenre : BaseEntity
    {
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}