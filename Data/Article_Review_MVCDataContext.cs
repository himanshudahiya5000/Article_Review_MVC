using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Article_Review_MVC.Models;

namespace Article_Review_MVC.Models
{
    public class Article_Review_MVCDataContext : DbContext
    {
        public Article_Review_MVCDataContext (DbContextOptions<Article_Review_MVCDataContext> options)
            : base(options)
        {
        }

        public DbSet<Article_Review_MVC.Models.Article> Article { get; set; }

        public DbSet<Article_Review_MVC.Models.Author> Author { get; set; }

        public DbSet<Article_Review_MVC.Models.Reviewer> Reviewer { get; set; }
    }
}
