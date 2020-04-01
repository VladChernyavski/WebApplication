using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppChernyavskiy.Models.Collections {
    public class CollectionContext : DbContext{

        public DbSet<Collection> Collections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Item> Items { get; set; }

        public CollectionContext(DbContextOptions<CollectionContext> options) : base(options) {
            Database.EnsureCreated();
        }

    }
}
