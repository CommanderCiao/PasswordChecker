using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace PasswordChecker.Models
{
    public class CompromisedAccount
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(256)] public string Username { get; set; } = null!;
        [Required, MaxLength(512)] public string PasswordHash { get; set; } = null!;
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CompromisedAccount> CompromisedAccounts => Set<CompromisedAccount>();

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<CompromisedAccount>().ToTable("CompromisedAccounts");
        }
    }



}
