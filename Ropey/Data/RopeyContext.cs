using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ropey.Models;

namespace Ropey.Data
{
    public partial class RopeyContext : DbContext
    {
        public RopeyContext()
        {
        }

        public RopeyContext(DbContextOptions<RopeyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<CastMember> CastMembers { get; set; } = null!;
        public virtual DbSet<Dvdcategory> Dvdcategories { get; set; } = null!;
        public virtual DbSet<Dvdcopy> Dvdcopies { get; set; } = null!;
        public virtual DbSet<Dvdtitle> Dvdtitles { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<LoanType> LoanTypes { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MembershipCategory> MembershipCategories { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<Studio> Studios { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=Ropey; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorNumber)
                    .HasName("PK__Actor__61277E04D8E13C3A");
            });

            modelBuilder.Entity<CastMember>(entity =>
            {
                entity.HasOne(d => d.ActorNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ActorNumber)
                    .HasConstraintName("FK__CastMembe__Actor__37A5467C");

                entity.HasOne(d => d.DvdnumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Dvdnumber)
                    .HasConstraintName("FK__CastMembe__DVDNu__36B12243");
            });

            modelBuilder.Entity<Dvdcategory>(entity =>
            {
                entity.HasKey(e => e.CategoryNumber)
                    .HasName("PK__DVDCateg__C8A2DE00CD326613");
            });

            modelBuilder.Entity<Dvdcopy>(entity =>
            {
                entity.HasKey(e => e.CopyNumber)
                    .HasName("PK__DVDCopy__DC6AA2FE24B58331");

                entity.HasOne(d => d.DvdnumberNavigation)
                    .WithMany(p => p.Dvdcopies)
                    .HasForeignKey(d => d.Dvdnumber)
                    .HasConstraintName("FK__DVDCopy__DVDNumb__34C8D9D1");
            });

            modelBuilder.Entity<Dvdtitle>(entity =>
            {
                entity.HasKey(e => e.Dvdnumber)
                    .HasName("PK__DVDTitle__87FA34E3ADB69F69");

                entity.HasOne(d => d.CategoryNumberNavigation)
                    .WithMany(p => p.Dvdtitles)
                    .HasForeignKey(d => d.CategoryNumber)
                    .HasConstraintName("FK__DVDTitle__Catego__2E1BDC42");

                entity.HasOne(d => d.ProducerNumberNavigation)
                    .WithMany(p => p.Dvdtitles)
                    .HasForeignKey(d => d.ProducerNumber)
                    .HasConstraintName("FK__DVDTitle__Produc__300424B4");

                entity.HasOne(d => d.StudioNumberNavigation)
                    .WithMany(p => p.Dvdtitles)
                    .HasForeignKey(d => d.StudioNumber)
                    .HasConstraintName("FK__DVDTitle__Studio__2F10007B");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.LoanNumber)
                    .HasName("PK__Loan__EEC26629F732F270");

                entity.HasOne(d => d.CopyNumberNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CopyNumber)
                    .HasConstraintName("FK__Loan__CopyNumber__403A8C7D");

                entity.HasOne(d => d.LoanTypeNumberNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.LoanTypeNumber)
                    .HasConstraintName("FK__Loan__LoanTypeNu__3F466844");

                entity.HasOne(d => d.MemberNumberNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.MemberNumber)
                    .HasConstraintName("FK__Loan__MemberNumb__412EB0B6");
            });

            modelBuilder.Entity<LoanType>(entity =>
            {
                entity.HasKey(e => e.LoanTypeNumber)
                    .HasName("PK__LoanType__DF3922CB6E08C2F9");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberNumber)
                    .HasName("PK__Member__F9D9F88FB2E9234E");

                entity.HasOne(d => d.MembershipCategoryNumberNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.MembershipCategoryNumber)
                    .HasConstraintName("FK__Member__Membersh__3A81B327");
            });

            modelBuilder.Entity<MembershipCategory>(entity =>
            {
                entity.HasKey(e => e.MembershipCategoryNumber)
                    .HasName("PK__Membersh__6D4F747059D655F3");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => e.ProducerNumber)
                    .HasName("PK__Producer__74FF745E409440CA");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.HasKey(e => e.StudioNumber)
                    .HasName("PK__Studio__084073AF9290C359");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserNumber)
                    .HasName("PK__Users__578B7EF73F1CE74D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
