using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using core.Data.DbContext;
using core.Domain.People.Entities;
using Microsoft.EntityFrameworkCore;

namespace core.Data.Repositories
{
    public class PersonRepository
    {
        private DataContext dbContext;
        private DbSet<Person> DbSet;


        public PersonRepository(DataContext mainContext)
        {
            dbContext = mainContext;
            DbSet = dbContext.Set<Person>();
        }

        public virtual Person Add(Person entity)
        {
            entity = DbSet.Add(entity).Entity;
            dbContext.SaveChanges();
            return entity;
        }

        public virtual IEnumerable<Person> Find(Expression<Func<Person, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }


    }
}