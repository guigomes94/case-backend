using Microsoft.EntityFrameworkCore;
using CaseBackend.Models;

namespace CaseBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Area> Areas { get; set; }

        public DbSet<Processo> Processos { get; set; }
    }
}