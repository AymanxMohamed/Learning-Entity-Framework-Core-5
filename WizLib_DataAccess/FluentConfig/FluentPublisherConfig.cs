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
    public class FluentPublisherConfig : IEntityTypeConfiguration<FluentPublisher>
    {
        public void Configure(EntityTypeBuilder<FluentPublisher> builder)
        {
            builder.HasKey(b => b.PublisherId);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Location).IsRequired();
        }
    }
}
