using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace University.Models
{
    public class UniversityContext : DbContext
    {
        private readonly IConfiguration configuration;
           public UniversityContext(DbContextOptions<UniversityContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("UniversityDatabaseConnection"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PasswordHasher<UserInfo> passwordHasher = new PasswordHasher<UserInfo>();

            modelBuilder.Entity<UserInfo>().HasData(
                    new UserInfo
                    {
                        Id = 1000,
                        Password = passwordHasher.HashPassword(new UserInfo(), "admin"),
                        Email = "andrei.carafa@ubbcluj.ro",
                        FirstName = "Andrei",
                        LastName = "Carafa",
                        CreatedAt = DateTime.Now,
                        Role = "student"
                    }
                );
        }
        public DbSet<Course> CoursesItems { get; set; } = null!;
        public DbSet<Grade> GradesItems { get; set; } = null!;
        public DbSet<Session> SessionItems { get; set; } = null!;
        public DbSet<Student> StudentsItems { get; set; } = null!;
        public DbSet<Teacher> TeachersItems { get; set; } = null!;
        public DbSet<UserInfo> UsersItems { get; set; } = null!;
    }

}