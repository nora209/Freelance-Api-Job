using App.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Database
{
    public class Context:DbContext
    {
        public DbSet<patient> patients { set; get; }
        public DbSet<Issue> issues { set; get; }
        public Context(DbContextOptions options) : base(options)
        {
                    
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
