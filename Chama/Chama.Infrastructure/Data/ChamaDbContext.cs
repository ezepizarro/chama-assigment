using Chama.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Infrastructure.Data
{
    public class ChamaDbContext : DbContext
    {
        public ChamaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSession>(entity => {
                entity.HasKey(e => new { e.StudentId, e.SessionId });
            });
            modelBuilder.Entity<StudentSession>(entity => {
                entity.HasOne(e => e.Student)
                .WithMany(s => s.StudentSessions)
                .HasForeignKey(e => e.StudentId);
            });
            modelBuilder.Entity<StudentSession>(entity => {
                entity.HasOne(e => e.Session)
                .WithMany(s => s.StudentSessions)
                .HasForeignKey(e => e.SessionId);
            });


            //Seed
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Scoot", LastName = "Reynolds", Age = 22, CreatedDate = DateTime.Now, Email = "sco@sco.com" },
                new Student { Id = 2, FirstName = "Rory", LastName = "Lee", Age = 33, CreatedDate = DateTime.Now, Email = "rory@rory.com" },
                new Student { Id = 3, FirstName = "Oliver", LastName = "Mendoza", Age = 43, CreatedDate = DateTime.Now, Email = "oli@oli.com" },
                new Student { Id = 4, FirstName = "Aidan", LastName = "Mayo", Age = 19, CreatedDate = DateTime.Now, Email = "ai@ai.com" },
                new Student { Id = 5, FirstName = "Finlay", LastName = "Wolf", Age = 21, CreatedDate = DateTime.Now, Email = "fin@fin.com" },
                new Student { Id = 6, FirstName = "Westin", LastName = "Rush", Age = 23, CreatedDate = DateTime.Now, Email = "wes@wes.com" },
                new Student { Id = 7, FirstName = "Shay", LastName = "Woods", Age = 36, CreatedDate = DateTime.Now, Email = "shay@shay.com" }
                ); ;

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Python", Description = "Go from Zero", CreatedDate = DateTime.Now },
                new Course { Id = 2, Name = "Net", Description = "Beginner to Advance", CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "Sam", LastName = "Jones", CreatedDate = DateTime.Now },
                new Teacher { Id = 2, FirstName = "Calvin", LastName = "Mills", CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<Session>().HasData(
               new Session { Id = 1, CourseId = 1, MaxAge = 0, MinAge = 0, AvgAge = 0, MaxCapacity = 20, NumberOfStudents = 0, CreatedDate = DateTime.Now, TeacherId = 1 },
               new Session { Id = 2, CourseId = 2, MaxAge = 0, MinAge = 0, AvgAge = 0, MaxCapacity = 15, NumberOfStudents = 0, CreatedDate = DateTime.Now, TeacherId = 2 }
            );
        }
    }
}