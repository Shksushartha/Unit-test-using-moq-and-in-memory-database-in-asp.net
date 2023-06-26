using System;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using unitTest.Controllers;
using UnitTest.Data.Data;
using UnitTest.Data.Models;
using UnitTest.Data.Repositorys;

namespace unitTest.Test
{
    public class PersonRepoTest
    {
        private readonly PersonDbContext _inMemDbContext;
        private readonly Repository _repository;
        public PersonRepoTest()
        {
            _inMemDbContext = GetInMemoryContext();
            _repository = new Repository(_inMemDbContext);
        }

        //private readonly Mock<PersonDbContext> _personDbMock = new Mock<PersonDbContext>();

        //public PersonRepoTest()
        //{
        //    _repository = new Repository(_personDbMock.Object);
        //}


        private PersonDbContext GetInMemoryContext()
        {
            var builder = new DbContextOptionsBuilder<PersonDbContext>();
            builder.UseInMemoryDatabase("TestDatabase");
            return new PersonDbContext(builder.Options);
        }

        private List<Person> GetFakePersonList()
        {
            return new List<Person>()
    {
        new Person
        {
            Id = 1,
            Name = "John Doe",
            Email = "J.D@gmail.com",
            Address = "123-456-7890"
        },
        new Person
        {
            Id = 2,
            Name = "Mark Luther",
            Email = "M.L@gmail.com",
            Address = "123-456-7890"
        }
    };

        }

        [Fact]
        public async Task Add_Test()
        {
            var fakePerson = new PersonRepoTest();
            var data = fakePerson.GetFakePersonList();
            var personContextMock = new Mock<PersonDbContext>();
            personContextMock.Setup(x => x.Persons)
                .ReturnsDbSet(data);

            //Act
            Repository repository = new Repository(personContextMock.Object);
            var persons = (await repository.GetAll()).ToList();

            //Assert
            Assert.NotNull(persons);
        }

        /*[Fact]
        public async Task Add_Test_Queryable()
        {
            var fakePerson = new PersonRepoTest();
            var data = fakePerson.GetFakePersonList();
            var personContextMock = new Mock<PersonDbContext>();
            personContextMock.Setup(x => x.Persons.FirstOrDefault())
                .Returns(data.FirstOrDefault(x => x.Id == 1) );
            
            Repository repository = new Repository(personContextMock.Object);
            Person person = await repository.GetById(1);
            
            Assert.NotNull(person);
            Assert.Equal(1, person.Id);
        }*/

        [Fact]
        public async Task Create_Test()
        {
            List<Person> people = GetFakePersonList();
            Person p1 = people[0];
            bool flag = await _repository.Add(p1);

            var p2 = await _repository.GetById(p1.Id);

            Assert.Equal(p1.Name, p2.Name);
        }
    }
}

