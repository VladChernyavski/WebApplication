using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy.Models.Account {
    public class UserContext : IdentityDbContext<User> {

        public DbSet<Collection> Collections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Item> Items { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
