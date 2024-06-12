using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SMS.Models;

public partial class StudentManagementContext : DbContext
{
    public StudentManagementContext()
    {
    }

    public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectMark> SubjectMarks { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source = UDAY; Initial Catalog = Student_Management; Integrated Security = True; Trust Server Certificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A0D4362CD3");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassTeacherId).HasColumnName("class_teacher_id");

            entity.HasOne(d => d.ClassTeacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ClassTeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Class_classTeacherID_FK");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => new { e.Studentid, e.Classid, e.Subjectid }).HasName("PK__rank__43ED70A705E1F5DA");

            entity.ToTable("rank");

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Classid).HasColumnName("classid");
            entity.Property(e => e.Subjectid).HasColumnName("subjectid");
            entity.Property(e => e.Marks).HasColumnName("marks");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.RollNo).HasName("PK__Student__28B6682D56D2E57C");

            entity.ToTable("Student", tb => tb.HasTrigger("tr_student_insert"));

            entity.Property(e => e.RollNo).HasColumnName("Roll_No");
            entity.Property(e => e.Address).HasMaxLength(25);
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.Contact).HasMaxLength(10);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalMarks)
                .HasDefaultValue(0)
                .HasColumnName("Total_marks");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_ClassID_FK");
        });

        modelBuilder.Entity<StudentSubject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Student_Subjects");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StudentSubjects_StudentID_FK");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StudentSubjects_SubjectID_FK");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__SUBJECTS__AC1BA388ED887B27");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("SubjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Subject_Name");
        });

        modelBuilder.Entity<SubjectMark>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Subject_Marks", tb =>
                {
                    tb.HasTrigger("tr_studentsubjects_insert");
                    tb.HasTrigger("tr_totalmarks_insert");
                });

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SubjectMarks_StudentID_FK");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SubjectMarks_SubjectID_FK");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF259440C5089D7");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .ValueGeneratedNever()
                .HasColumnName("TeacherID");
            entity.Property(e => e.Address)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Contact).HasMaxLength(10);
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
