using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.Data
{
    public class AppdbContext : IdentityDbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options)
            :base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
