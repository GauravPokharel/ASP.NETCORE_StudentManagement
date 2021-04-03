using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.DbContexts
{
    public class ADbContexts : IdentityDbContext<IdentityUser>
    {
        public ADbContexts(DbContextOptions<ADbContexts> options)
            : base(options)
        { }
        /*public ADbContexts(){}*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-7A0URME;Database=StudentManagement;Trusted_Connection=true; connect timeout=500;");
        }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Marks> Marks { get; set; }
    }
}
