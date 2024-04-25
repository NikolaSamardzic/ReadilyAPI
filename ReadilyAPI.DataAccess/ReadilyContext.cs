﻿using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<Review>().ToTable(x => x.HasCheckConstraint("CK_Stars","[Stars] > 0 AND [Stars] < 6"));

            base.OnModelCreating(modelBuilder);
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
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentImage> CommentImage { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<BookOrder> BookOrder { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
