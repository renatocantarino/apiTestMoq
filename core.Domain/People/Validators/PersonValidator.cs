using core.Domain.People.Entities;
using FluentValidation;

namespace core.Domain.People.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não informado");;
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Sobrenome não informado");;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail can't be empty.")
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("E-mail is not in valid format.")
                .MaximumLength(20).WithMessage("E-mail length must be maximum 20.");
        }
    }
}