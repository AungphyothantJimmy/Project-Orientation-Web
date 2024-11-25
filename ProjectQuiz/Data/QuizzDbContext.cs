using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectQuiz.Data;

public partial class QuizzDbContext : DbContext
{
    public QuizzDbContext()
    {
    }

    public QuizzDbContext(DbContextOptions<QuizzDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectComment> ProjectComments { get; set; }

    public virtual DbSet<ProjectMember> ProjectMembers { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizResult> QuizResults { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserQuiz> UserQuizzes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AUNGPHYOTHANT\\SQLEXPRESS;Initial Catalog=QuizzDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3214EC0775BD7704");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IntroductionVideoUrl).HasMaxLength(500);
            entity.Property(e => e.LastUpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LocalVideoPath).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.YouTubeVideoUrl).HasMaxLength(500);

            entity.HasOne(d => d.User).WithMany(p => p.Projects)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Projects__UserId__4AB81AF0");
        });

        modelBuilder.Entity<ProjectComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectC__3214EC07EFA354B3");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("text");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectComments)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ProjectCo__Proje__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectComments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ProjectCo__UserI__47DBAE45");
        });

        modelBuilder.Entity<ProjectMember>(entity =>
        {
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_ProjectMembers_Projects");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ProjectMembers_Users");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quizzes__8B42AE8ECE7802EB");

            entity.Property(e => e.CorrectAnswer).HasColumnType("text");
            entity.Property(e => e.QuestionText).HasMaxLength(255);
            entity.Property(e => e.QuestionType).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Project).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Quizzes__Project__3C69FB99");
        });

        modelBuilder.Entity<QuizResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QuizResu__3214EC074EA3AF5F");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SelectedAnswer).HasMaxLength(255);

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizResults)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuizResul__QuizI__4BAC3F29");

            entity.HasOne(d => d.User).WithMany(p => p.QuizResults)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuizResul__UserI__4CA06362");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07285F25DF");

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<UserQuiz>(entity =>
        {
            entity.HasKey(e => e.UserQuizId).HasName("PK__UserQuiz__20FA6387D5E6A855");

            entity.ToTable("UserQuiz");

            entity.Property(e => e.TotalScore).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Project).WithMany(p => p.UserQuizzes)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserQuiz__Projec__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.UserQuizzes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserQuiz__UserId__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
