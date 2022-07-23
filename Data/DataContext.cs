using Microsoft.EntityFrameworkCore;
using OnqueteApi.Models;

namespace OnqueteApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Survey> surveys { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<QuestionType> question_types { get; set; }
    }
}