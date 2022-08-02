using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace data
{
    public partial class GuzelSozContext : DbContext
    {
        public GuzelSozContext(DbContextOptions<GuzelSozContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlServer("Data Source=SELCUKPC\\SQLEXPRESS;Initial Catalog=GuzelSozlerDB;Integrated Security=SSPI;");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryImg)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostImg)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostSummary).IsRequired();

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category");
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentDate)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_Comment_Post");
            });
            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.ReplyDate)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Comment)
                .WithMany(p => p.Replies)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK_Reply_Comment");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
