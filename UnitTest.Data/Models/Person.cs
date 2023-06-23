using System;
namespace UnitTest.Data.Models
{
    public class Person
    {
        public Person()
        {
        }
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}

