using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalApi.DAL.Entities;

namespace TraversalApi.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ONUR-BILGISAYAR;Database=TraversalDb;initial catalog=TraversalDbApi;integrated security=true;");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
