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
    public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
    {
        public void Configure(EntityTypeBuilder<FluentBook> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Isbn).HasMaxLength(15);
            builder.Property(b => b.Price).IsRequired();

            // one to one relation between FluentBook And FluentBookDetails
            builder.HasOne(b => b.FluentBookDetail)
                .WithOne(b => b.FluentBook)
                .HasForeignKey<FluentBook>("FluentBookDetailId");

            // one to many relation between FluentBook and FluentPublisher
            builder.HasOne(b => b.FluentPublisher)
                .WithMany(b => b.FluentBooks)
                .HasForeignKey(b => b.FluentPublisherId);

        }
    }
}
