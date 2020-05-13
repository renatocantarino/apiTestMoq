using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using core.Domain.People.Entities;

namespace core.Domain.People.Interfaces
{
    public interface IPersonRepository
    {
         Person Add(Person entity);
         IEnumerable<Person> Find(Expression<Func<Person, bool>> predicate);

    }
}