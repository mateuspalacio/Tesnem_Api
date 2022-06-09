﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tesnem.Api.Data;

#nullable disable

namespace Tesnem.Api.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CourseCourseRequirement", b =>
                {
                    b.Property<Guid>("RequirementsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RequirementsId1")
                        .HasColumnType("char(36)");

                    b.HasKey("RequirementsId", "RequirementsId1");

                    b.HasIndex("RequirementsId1");

                    b.ToTable("CourseCourseRequirement");
                });

            modelBuilder.Entity("CourseProfessor", b =>
                {
                    b.Property<Guid>("ProfessorsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherOfCoursesId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProfessorsId", "TeacherOfCoursesId");

                    b.HasIndex("TeacherOfCoursesId");

                    b.ToTable("CourseProfessor");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<Guid>("CoursesCurrentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("char(36)");

                    b.HasKey("CoursesCurrentId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("PastCoursesStudent", b =>
                {
                    b.Property<Guid>("CoursesCompletedIdId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentsWhoCompletedId")
                        .HasColumnType("char(36)");

                    b.HasKey("CoursesCompletedIdId", "StudentsWhoCompletedId");

                    b.HasIndex("StudentsWhoCompletedId");

                    b.ToTable("PastCoursesStudent");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Course_Id")
                        .HasColumnType("char(36)");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProfessorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Professor_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Program_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Program_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.CourseRequirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CourseRequirement");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EnrollmentNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.PastCourses", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("PastCourses");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.PersonalData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AdditionalAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AddressHouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("PersonalData");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.ProgramMajor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Av")
                        .HasColumnType("int");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Grade")
                        .HasColumnType("double");

                    b.Property<Guid>("Student_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("Student_Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Professor", b =>
                {
                    b.HasBaseType("Tesnem.Api.Domain.Models.Person");

                    b.HasDiscriminator().HasValue("Professor");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Student", b =>
                {
                    b.HasBaseType("Tesnem.Api.Domain.Models.Person");

                    b.Property<DateTime>("ConclusionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ProgramMajorId")
                        .HasColumnType("char(36)");

                    b.HasIndex("ProgramMajorId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("CourseCourseRequirement", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("RequirementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.CourseRequirement", null)
                        .WithMany()
                        .HasForeignKey("RequirementsId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseProfessor", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("TeacherOfCoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCurrentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PastCoursesStudent", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.PastCourses", null)
                        .WithMany()
                        .HasForeignKey("CoursesCompletedIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsWhoCompletedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Class", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany("Classes")
                        .HasForeignKey("CourseId");

                    b.HasOne("Tesnem.Api.Domain.Models.Professor", null)
                        .WithMany("TeacherOfClasses")
                        .HasForeignKey("ProfessorId");

                    b.HasOne("Tesnem.Api.Domain.Models.Student", null)
                        .WithMany("Classes")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Course", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.ProgramMajor", "Program")
                        .WithMany("Courses")
                        .HasForeignKey("Program_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Enrollment", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Person", null)
                        .WithOne("Enrollment")
                        .HasForeignKey("Tesnem.Api.Domain.Models.Enrollment", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.PersonalData", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Person", "Person")
                        .WithOne("Data")
                        .HasForeignKey("Tesnem.Api.Domain.Models.PersonalData", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Test", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.Class", null)
                        .WithMany("Tests")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Course", null)
                        .WithMany("Tests")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tesnem.Api.Domain.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Student", b =>
                {
                    b.HasOne("Tesnem.Api.Domain.Models.ProgramMajor", "ProgramMajor")
                        .WithMany()
                        .HasForeignKey("ProgramMajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramMajor");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Class", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Course", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Person", b =>
                {
                    b.Navigation("Data")
                        .IsRequired();

                    b.Navigation("Enrollment")
                        .IsRequired();
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.ProgramMajor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Professor", b =>
                {
                    b.Navigation("TeacherOfClasses");
                });

            modelBuilder.Entity("Tesnem.Api.Domain.Models.Student", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
