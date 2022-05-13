using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class FluentBook
    {
        public int BookId { get; set; }

        public string Title { get; set; }


        public string Isbn { get; set; }

        public double Price { get; set; }

        public string PriceRange { get; set; }

        public int FluentBookDetailId { get; set; }
        public FluentBookDetail FluentBookDetail { get; set; }

        public int FluentPublisherId { get; set; }
        public FluentPublisher FluentPublisher { get; set; }

        public ICollection<FluentBookAuthor> FluentBookAuthors { get; set; }
    }   
}
