using FluentValidation;
using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Domain.Contracts;

namespace Matelso.ContactManager.Application.Validation
{
    public class ContactValidator : AbstractValidator<ContactDto>
    {
        private readonly IContactRepository _contactRepository;
        //public ContactValidator(IContactRepository contactRepository)
        //{
        //    _contactRepository = contactRepository;
        //}
        public ContactValidator(IContactRepository contactRepository)
        // public ContactValidator()
        {
            _contactRepository = contactRepository;


            RuleFor(p => p.Salutation)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(50);

            RuleFor(p => p.FirstName)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(50);

            RuleFor(p => p.LastName)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(50);

            RuleFor(p => p.BirthDate)
                .Must(BeAValidDate)
                .When(p => p.BirthDate.HasValue);

            RuleFor(p => p.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .Must(BeUniqueEmail)
                .WithMessage("Email address must be unique");
        }
        private bool BeAValidDate(DateTime? date)
        {
            return date.HasValue ? date.Value <= DateTime.Now : true;
        }

        private bool BeUniqueEmail(string email)
        {
            return _contactRepository.CheckEmailIsUnique(email);
        }
    }
}
