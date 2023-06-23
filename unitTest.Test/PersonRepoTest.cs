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
        //private readonly Repository _repository;
        //private readonly Mock<PersonDbContext> _personDbMock = new Mock<PersonDbContext>();

        //public PersonRepoTest()
        //{
        //    _repository = new Repository(_personDbMock.Object);
        //}
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
    }
}

