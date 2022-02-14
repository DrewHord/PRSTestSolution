using Microsoft.EntityFrameworkCore;
using PRSLibrary.Models;
using PRSTestProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Model {
    public class PRSDbContext : DbContext {


        public virtual  DbSet<User> Users { get; set; }
        public virtual  DbSet<Vendor> Vendors { get; set; }
        public virtual  DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestLine> RequestLines { get; set; }
        public PRSDbContext() { }

        public PRSDbContext(DbContextOptions<PRSDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseSqlServer("server =localhost\\sqlexpress;database=TestPrsDb;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            //makes Username in User unique
            builder.Entity<User>(e => {
                e.HasIndex(p => p.Username).IsUnique(true);
            });

            builder.Entity<Vendor>(e => {
                e.HasIndex(p => p.Code).IsUnique(true);
            });

            builder.Entity<Product>(e => {
                e.HasIndex(p => p.PartNbr).IsUnique(true);
            });
        }
    }
}
