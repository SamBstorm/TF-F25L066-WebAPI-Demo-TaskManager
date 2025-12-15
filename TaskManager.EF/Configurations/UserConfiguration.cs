using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.EF.Models;

namespace TaskManager.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(u => u.Email)
                .HasMaxLength(320)
                .IsRequired();
            builder
                .Property(u => u.Password)
                .HasColumnType("VARBINARY(32)")
                .IsRequired();
            builder
                .Property(u => u.Salt)
                .IsRequired();
            builder
                .Property(u => u.CreationDate)
                .HasColumnType("DateTime2")
                .HasDefaultValueSql("GetDate()")
                .IsRequired();
            builder
                .Property(u => u.Role)
                .HasDefaultValue("User")
                .IsRequired();
            builder
                .Property(u => u.DisableDate)
                .HasColumnType("DateTime2");

            builder
                .HasKey(u => u.UserId)
                .HasName("PK_User");



        }
    }
}
