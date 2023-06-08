using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models;

public class EfSuperLearningContext : DbContext
{
    public EfSuperLearningContext(DbContextOptions<EfSuperLearningContext> options)
        : base(options)
    {
    }

    public DbSet<SuperLearningUser> SuperLearningUsers { get; set; }
}