﻿// <auto-generated />
using System;
using Chama.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chama.Infrastructure.Migrations
{
    [DbContext(typeof(ChamaDbContext))]
    [Migration("20190711172933_Seeds")]
    partial class Seeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chama.Core.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(4181),
                            Description = "Go from Zero",
                            Name = "Python"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(4201),
                            Description = "Beginner to Advance",
                            Name = "Net"
                        });
                });

            modelBuilder.Entity("Chama.Core.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvgAge");

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("MaxAge");

                    b.Property<int>("MaxCapacity");

                    b.Property<int>("MinAge");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("NumberOfStudents");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvgAge = 0,
                            CourseId = 1,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(8569),
                            MaxAge = 0,
                            MaxCapacity = 20,
                            MinAge = 0,
                            NumberOfStudents = 0,
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            AvgAge = 0,
                            CourseId = 2,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(8970),
                            MaxAge = 0,
                            MaxCapacity = 15,
                            MinAge = 0,
                            NumberOfStudents = 0,
                            TeacherId = 2
                        });
                });

            modelBuilder.Entity("Chama.Core.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 22,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(8128),
                            Email = "sco@sco.com",
                            FirstName = "Scoot",
                            LastName = "Reynolds"
                        },
                        new
                        {
                            Id = 2,
                            Age = 33,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9011),
                            Email = "rory@rory.com",
                            FirstName = "Rory",
                            LastName = "Lee"
                        },
                        new
                        {
                            Id = 3,
                            Age = 43,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9019),
                            Email = "oli@oli.com",
                            FirstName = "Oliver",
                            LastName = "Mendoza"
                        },
                        new
                        {
                            Id = 4,
                            Age = 19,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9020),
                            Email = "ai@ai.com",
                            FirstName = "Aidan",
                            LastName = "Mayo"
                        },
                        new
                        {
                            Id = 5,
                            Age = 21,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9021),
                            Email = "fin@fin.com",
                            FirstName = "Finlay",
                            LastName = "Wolf"
                        },
                        new
                        {
                            Id = 6,
                            Age = 23,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9022),
                            Email = "wes@wes.com",
                            FirstName = "Westin",
                            LastName = "Rush"
                        },
                        new
                        {
                            Id = 7,
                            Age = 36,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9023),
                            Email = "shay@shay.com",
                            FirstName = "Shay",
                            LastName = "Woods"
                        });
                });

            modelBuilder.Entity("Chama.Core.Entities.StudentSession", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("SessionId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Id");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("StudentId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("StudentSession");
                });

            modelBuilder.Entity("Chama.Core.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(5666),
                            FirstName = "Sam",
                            LastName = "Jones"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(5683),
                            FirstName = "Calvin",
                            LastName = "Mills"
                        });
                });

            modelBuilder.Entity("Chama.Core.Entities.Session", b =>
                {
                    b.HasOne("Chama.Core.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Chama.Core.Entities.Teacher", "Teacher")
                        .WithMany("Sessions")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Chama.Core.Entities.StudentSession", b =>
                {
                    b.HasOne("Chama.Core.Entities.Session", "Session")
                        .WithMany("StudentSessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Chama.Core.Entities.Student", "Student")
                        .WithMany("StudentSessions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
