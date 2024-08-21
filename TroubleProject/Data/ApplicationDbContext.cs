using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TroubleProject.Models;

namespace TroubleProject.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Student> Students { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}