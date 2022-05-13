using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class FluentBookAuthor
    {
        public int FluentBookId { get; set; }
        public int FluentAuthorId { get; set; }
        public FluentBook FluentBook { get; set; }
        public FluentAuthor FluentAuthor { get; set; }
    }
}
