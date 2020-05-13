using System;
using core.Domain.People.Validators;
using FluentValidation;

namespace core.Domain.People.Entities
{
    public class Person : Base.BaseEntity
    {
        public Person(string name, string email, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Isvalid();
        }

        public Person(int Id, string name, string email, DateTime dateOfBirth)
        {
            this.Id = Id;
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        protected Person()
        {
        }

        public DateTime DateOfBirth { get; private set; }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public virtual bool Isvalid()
        {
            return Validate(this, new PersonValidator());
        }
    }
}