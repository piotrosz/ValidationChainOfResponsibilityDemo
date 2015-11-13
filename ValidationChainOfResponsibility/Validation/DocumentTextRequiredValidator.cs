using FluentValidation;

namespace ValidationChainOfResponsibility.Validation
{
    public class DocumentTextRequiredValidator : AbstractValidator<Document>
    {
        public DocumentTextRequiredValidator()
        {
            RuleFor(d => d.Text)
                .NotEmpty()
                .WithMessage("Text cannot be empty");
        }
    }
}
