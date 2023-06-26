using System;
using Microsoft.EntityFrameworkCore;
using UnitTest.Data.Models;

namespace UnitTest.Data.Data
{
    public class PersonDbContext : DbContext
    {

        public virtual DbSet<Person> Persons { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }

        public PersonDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

