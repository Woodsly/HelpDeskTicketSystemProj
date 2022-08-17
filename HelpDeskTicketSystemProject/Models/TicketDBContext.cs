using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HelpDeskTicketSystemProject.Models
{
    public partial class TicketDBContext : DbContext
    {
        public TicketDBContext()
        {
        }

        public TicketDBContext(DbContextOptions<TicketDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=TicketDB; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK__Favorite__Ticket__286302EC");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.DateClosed).HasColumnType("date");

                entity.Property(e => e.DateOpened).HasColumnType("date");

                entity.Property(e => e.QuestionDetails).HasMaxLength(4000);

                entity.Property(e => e.Resolution).HasMaxLength(4000);

                entity.Property(e => e.ResolvedBy).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.SubjectLine).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
