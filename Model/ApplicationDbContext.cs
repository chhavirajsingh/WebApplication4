using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication4.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("Data Source=CHETUIWK1702\\SQLEXPRESS;Initial Catalog=testdb5;Integrated Security=True;Pooling=False") { }
         public DbSet<Department> Departments { get; set; }
         public DbSet<Employee> Employees { get; set; }


    }
}