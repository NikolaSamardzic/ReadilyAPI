using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.DataAccess
{
    public class ReadilyContext : DbContext
    {
        private readonly string _connectionString;

        public ReadilyContext()
        {
            _connectionString = "Data Source=NIKOLA\\SQLEXPRESS;Initial Catalog=Readily;TrustServerCertificate=true;Integrated security = true";
        }

        public ReadilyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<Book>()
                .HasMany(x=>x.Categories)
                .WithMany(x=>x.Books)
                .UsingEntity<BookCategory>();

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Wishlist)
                .WithMany(x => x.Wishlist)
                .UsingEntity<Wishlist>();

            modelBuilder.Entity<Review>()
                .ToTable(x => x.HasCheckConstraint("CK_Stars","[Stars] > 0 AND [Stars] < 6"));

            modelBuilder.Entity<RoleUseCase>()
                .HasKey(x => new { x.RoleId, x.UseCaseId });

            modelBuilder.Entity<UserUseCase>()
                .HasKey(x => new { x.UserId, x.UseCaseId });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added && entry.Entity is Entity addedEntity)
                {
                    addedEntity.IsActive = true;
                    addedEntity.CreatedAt = DateTime.UtcNow;
                }else if (entry.State == EntityState.Modified && entry.Entity is Entity updatedEntity) {
                    updatedEntity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Book> Books { get; set; }  
        public DbSet<BookCategory> BooksCategories { get; set; }
        public DbSet<UserCategory> UsersCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentImage> CommentsImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<BookOrder> BooksOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
