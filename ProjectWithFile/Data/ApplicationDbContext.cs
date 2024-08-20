using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectWithFile.Models;

namespace ProjectWithFile.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<DollyModel> DollyModels { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}