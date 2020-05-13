using System.Collections.Generic;
using core.Domain.People.Entities;

namespace core.Domain.People.Interfaces
{
    public interface IPersonService
    {
        Person Add(Person entity);
        Person FindById(int id);
        IEnumerable<Person> GetAll();
    }
}