using Microsoft.EntityFrameworkCore;
using PracticeSystem.Models;

namespace PracticeSystem.Data
{
    
    public sealed class PracticeSystemContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Group> groupp { get; set; }
        public DbSet<Practice> prac { get; set; }
        public DbSet<PracticeHead> phead { get; set; }
        public DbSet<Student> stud { get; set; }
        
        public PracticeSystemContext(DbContextOptions<PracticeSystemContext> optionsBuilder) : base(optionsBuilder)
        {
            Database.EnsureCreated();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(x => x.user)
                .WithOne().HasForeignKey<Student>(x => x.sid);
        }
    }
}