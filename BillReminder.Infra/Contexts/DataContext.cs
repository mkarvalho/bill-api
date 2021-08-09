using BillReminder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillReminder.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }

    }
}
