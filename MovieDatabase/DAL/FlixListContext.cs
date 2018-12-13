using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieDatabase.DAL
{
    public class FlixListContext : DbContext
    {
        public FlixListContext() : base("FlixListContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserLibrary> UserLibraries { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}