using Microsoft.EntityFrameworkCore;
using Prestamos_Backend.Module.Auth.Entities;

namespace Prestamos_Backend.DATA;
public class DataContext(DbContextOptions<DataContext> dbContext) : DbContext(dbContext)
{
    public DbSet<User> Users  => Set<User>();
}