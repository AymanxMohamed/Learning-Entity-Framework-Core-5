using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(15)]
        public string Isbn { get; set; }

        [Required]
        public double Price { get; set; }

        [NotMapped]
        public string PriceRange { get; set; }

        [ForeignKey("BookDetail")]
        public int? BookDetailsId { get; set; }

        public BookDetail BookDetail { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
