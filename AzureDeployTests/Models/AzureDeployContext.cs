using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AzureDeployTests.Models
{
    public class AzureDeployContext : DbContext
    {
        public AzureDeployContext() : base("database")
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}