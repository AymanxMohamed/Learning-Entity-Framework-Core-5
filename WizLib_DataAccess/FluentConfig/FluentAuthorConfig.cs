using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Model.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentAuthor> builder)
        {
            builder.HasKey(b => b.AuthorId);
            builder.Property(b => b.FullName).IsRequired();
            builder.Property(b => b.LastName).IsRequired();
            builder.Property(b => b.BirthDate).IsRequired();
            builder.Ignore(b => b.FullName);
        }
    }
}
