using System.Collections.Generic;
using System.Linq;
using core.Domain.People.Entities;
using core.Domain.People.Interfaces;

namespace core.Domain.People.Services
{
    public class PersonService : Interfaces.IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Add(Person entity)
        {
            if (!entity.IsValid)
                return entity;

            return _repository.Add(entity);
        }

        public Person FindById(int id)
        {
            return _repository.Find(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.Find(p => true);
        }
    }
}