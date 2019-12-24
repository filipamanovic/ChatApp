using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(m => m.Text).HasMaxLength(500);
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasOne<User>(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserID);
        }
    }
}
