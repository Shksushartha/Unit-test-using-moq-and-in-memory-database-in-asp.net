using System;
using UnitTest.Data.Models;

namespace UnitTest.Data.Repositorys
{
    public interface IRepository
    {
        public Task<bool> Add(Person p);
        public Task<IEnumerable<Person>> GetAll();

        public Task<Person> GetById(int id);
    }
}

