using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net.Database
{
    public class HenryContext : DbContext
    {
        public HenryContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Image { get; set; }


        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
