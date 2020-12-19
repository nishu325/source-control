using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Context : DbContext
    {
        public DbSet <Employee> employees { get; set; }
        public DbSet <NLog> logs { get; set; }
    }
}