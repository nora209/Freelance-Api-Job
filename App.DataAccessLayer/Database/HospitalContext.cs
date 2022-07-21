using App.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Database
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { set; get; } = null!; //First method to solve null wanrning issue
        public DbSet<Issue> Issues => Set<Issue>(); //Second method to solve null wanrning issue
        public HospitalContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
