using Lab22MoviePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab22MoviePractice.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<MovieModel> Movies { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieModel>().Property(x => x.Title).HasMaxLength(50);
        }
    }
}
