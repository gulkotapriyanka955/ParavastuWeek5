using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParavastuWeek5.Models
{
    public partial class NPGoldContext : DbContext
    {
        public NPGoldContext()
        {
        }

        public NPGoldContext(DbContextOptions<NPGoldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Representative> Representatives { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:NPGoldConnString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustNumber)
                    .HasName("pk_customer");

                entity.ToTable("customer");

                entity.Property(e => e.CustNumber).HasColumnName("cust_Number");

                entity.Property(e => e.CustAmountPaid)
                    .HasColumnType("money")
                    .HasColumnName("cust_Amount_Paid");

                entity.Property(e => e.CustBalance)
                    .HasColumnType("money")
                    .HasColumnName("cust_Balance");

                entity.Property(e => e.CustName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cust_Name")
                    .IsFixedLength();

                entity.Property(e => e.CustRepId).HasColumnName("cust_RepID");

                entity.Property(e => e.CustStreet)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cust_Street");

                entity.Property(e => e.CustTelephone)
                    .HasMaxLength(24)
                    .HasColumnName("cust_Telephone")
                    .IsFixedLength();

                entity.HasOne(d => d.CustRep)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustRepId)
                    .HasConstraintName("fk_rep_cust");
            });

            modelBuilder.Entity<Representative>(entity =>
            {
                entity.HasKey(e => e.RepId)
                    .HasName("pk_representative");

                entity.ToTable("Representative");

                entity.Property(e => e.RepId).HasColumnName("RepID");

                entity.Property(e => e.RepFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RepLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RepSalary).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
