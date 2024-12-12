using System;
using core_dotnet7_sqlsrv.Models;
using Microsoft.EntityFrameworkCore;

namespace core_dotnet7_sqlsrv.Data
{
	public class ApplicationDbContext: DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is User &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var entity = (User)entityEntry.Entity;
                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow.AddHours(7);
                }
                entity.UpdatedAt = DateTime.UtcNow.AddHours(7);
            }

            return base.SaveChanges();
        }
    }
}

