using FluentValidation;
using Matelso.ContactManager.Application.Interfaces.Repositories;
using Matelso.ContactManager.Domain.Contracts;

namespace Matelso.ContactManager.Application.Validation
{
    public class ContactValidator : AbstractValidator<ContactDto>
    {
        private readonly IContactRepository _contactRepository;
        public ContactValidator(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public ContactValidator()
        {
            RuleFor(p => p.Salutation)
           .NotEmpty()
           .MinimumLength(2)
           .MaximumLength(50)
           .When(p => !string.IsNullOrEmpty(p.Salutation));

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .When(p => !string.IsNullOrEmpty(p.FirstName));

            RuleFor(p => p.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .When(p => !string.IsNullOrEmpty(p.LastName));

            RuleFor(p => p.DisplayName)
                .NotEmpty()
                .When(p => string.IsNullOrEmpty(p.Salutation) && string.IsNullOrEmpty(p.FirstName) && string.IsNullOrEmpty(p.LastName))
                .MaximumLength(150);

            RuleFor(p => p.BirthDate)
                .Must(BeAValidDate)
                .When(p => p.BirthDate.HasValue);

            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(BeUniqueEmail)
                .WithMessage("Email address must be unique");
        }
        private bool BeAValidDate(DateTime? date)
        {
            return date.HasValue ? date.Value <= DateTime.Now : true;
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {

            return await _contactRepository.CheckEmailIsUnique(email);
            // Implement your logic to check if the email is unique
            // For example, you can check if there's already a person in the database with the same email
        }
    }
}
