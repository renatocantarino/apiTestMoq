using core.Domain.People.Entities;
using core.Domain.People.Interfaces;
using core.Domain.People.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace Tests.Domain.Units
{
    public class PersonServiceTest
    {
        Mock<Person> _personMock;
        private Mock<IPersonRepository> _repositoryMock;
        PersonService _service;

        public PersonServiceTest()
        {
            _repositoryMock = new Mock<IPersonRepository>();
            _personMock = new Mock<Person>();
            _service = new PersonService(_repositoryMock.Object);
        }

        [Fact]
        public void Add_WhenPersonIsNotValid_ShouldNotCallRepository()
        {
            _personMock.Setup(x => x.Isvalid()).Returns(false);

            _service.Add(_personMock.Object);

            _repositoryMock.Verify(x => x.Add(_personMock.Object), Times.Never);
        }

        [Fact]
        public void FindById_ShouldCallRepository_AndReturnPersonFromRepository()
        {
            var expected = new Person("abc", "abc@test.com", new DateTime(1990, 01, 02));
            _repositoryMock.Setup(x => x.Find(It.IsAny<Expression<Func<Person, bool>>>())).Returns(new List<Person> { expected });

            var result = _service.FindById(It.IsAny<int>());

            _repositoryMock.Verify(x => x.Find(It.IsAny<Expression<Func<Person, bool>>>()), Times.Once);
        }
    }
}