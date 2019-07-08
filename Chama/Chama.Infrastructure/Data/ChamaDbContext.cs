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
        }
    }
}