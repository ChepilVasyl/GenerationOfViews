using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondAttempt.Models.MyModels;

namespace SecondAttempt.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Student> Students { get; set; }
    //public DbSet<Subject> Subjects { get; set; }
    //public DbSet<Teacher> Teachers { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}