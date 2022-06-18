using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Logique_api.Models
{
    public class LogiqueDbContext : DbContext
    {
        public LogiqueDbContext() : base("name=LogiqueDbContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<DetailUser> DetailUsers { get; set; }
        public DbSet<AddressUser> AddressUsers { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            var username = "System";

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;
                ((BaseEntity)entityEntry.Entity).UpdatedBy = username;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedBy = username;
                }
            }

            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>()
                .HasRequired(x => x.DetailUser)
                .WithMany()
                .HasForeignKey(x => x.DetailUserID);

            modelBuilder.Entity<DetailUser>()
                .HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}