using Microsoft.EntityFrameworkCore;
using OnqueteApi.Models;

namespace OnqueteApi.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> users { get; set; }
  }
}