using FluentValidation;

namespace ValidationChainOfResponsibility.Validation
{
    public class DocumentTextLengthValidator : AbstractValidator<Document>
    {
        public DocumentTextLengthValidator()
        {
            RuleFor(d => d.Text)
                .Must(d => d.Length > 1000)
                .WithMessage("Text length cannot be less than 1000");
        }
    }
}
