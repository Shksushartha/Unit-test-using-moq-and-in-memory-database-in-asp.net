using System;
using UnitTest.Data.Data;
using UnitTest.Data.Models;
using UnitTest.Data.Repositorys;

namespace UnitTest.Data.Repositorys
{
    public class Repository : IRepository
    {
        private readonly PersonDbContext _personDbContext;

        public Repository(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }

        public async Task<bool> Add(Person p)
        {

            _personDbContext.Persons.Add(p);
            await _personDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var persons = _personDbContext.Persons.ToList();
            return persons;
        }
    }
}

