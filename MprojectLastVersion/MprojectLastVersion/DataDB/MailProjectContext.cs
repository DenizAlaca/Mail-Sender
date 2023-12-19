using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MprojectLastVersion.DataDB
{
    public partial class MailProjectContext : DbContext
    {
        public MailProjectContext()
        {
        }

        public MailProjectContext(DbContextOptions<MailProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<MailAddress> MailAddresses { get; set; }
        public virtual DbSet<MailAddressGroup> MailAddressGroups { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=31.186.11.154;Database=sec5alerekaccom_vris;User Id = sec5alerekaccom_vrisadmin; Password=Emirgok5328*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasMaxLength(300);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.FromEmailAddress).HasMaxLength(300);

                entity.Property(e => e.FromName).HasMaxLength(300);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MailSendAddress).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.Subject).HasMaxLength(450);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(300);
            });

            modelBuilder.Entity<MailAddress>(entity =>
            {
                entity.ToTable("MailAddress");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(300);

                entity.Property(e => e.LastName).HasMaxLength(300);

                entity.Property(e => e.MailAddress1)
                    .HasMaxLength(300)
                    .HasColumnName("MailAddress");
            });

            modelBuilder.Entity<MailAddressGroup>(entity =>
            {
                entity.ToTable("MailAddressGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MailAddressId).HasColumnName("MailAddressID");

                entity.Property(e => e.SubscriptionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(150);

                entity.Property(e => e.FristName).HasMaxLength(300);

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(300);

                entity.Property(e => e.Password).HasMaxLength(16);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
