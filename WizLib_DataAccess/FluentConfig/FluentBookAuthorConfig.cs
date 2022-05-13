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
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<FluentBookAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentBookAuthor> builder)
        {
            builder.HasKey(b => new { b.FluentBookId, b.FluentAuthorId });

            builder
                .HasOne(b => b.FluentBook)
                .WithMany(b => b.FluentBookAuthors)
                .HasForeignKey(b => b.FluentBookId);

            builder.HasOne(b => b.FluentAuthor)
                .WithMany(b => b.FluentBookAuthors)
                .HasForeignKey(b => b.FluentAuthorId);
        }
    }
}
