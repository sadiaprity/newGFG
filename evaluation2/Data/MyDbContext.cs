using System;
using evaluation2.Models;
using Microsoft.EntityFrameworkCore;

namespace evaluation2.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
       public DbSet<Users> Users { get; set; }
       public DbSet<Volunteer> Volunteer { get; set; }

        public DbSet<Notice> Notice{ get; set; }


    }
}
