using FluentValidation;

namespace ValidationChainOfResponsibility.Validation
{
    public class DocumentTextLengthValidator : AbstractValidator<Document>
    {
        public DocumentTextLengthValidator()
        {
            RuleFor(d => d.Text.Length)
                .GreaterThan(1000)
                .WithMessage("Text length cannot be less than {ComparisonValue}");
        }
    }
}
