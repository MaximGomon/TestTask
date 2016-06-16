using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAL.Entities;

namespace DAL
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public UserDbContext() : base ("ConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; } 
    }
}