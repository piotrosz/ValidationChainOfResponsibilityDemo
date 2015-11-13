using FluentValidation;

namespace ValidationChainOfResponsibility.Validation
{
    public class DocumentTextContentValidator : AbstractValidator<Document>
    {
        public DocumentTextContentValidator()
        {
            RuleFor(d => d.Text)
                .Must(t => t.Contains("Piotr"))
                .WithMessage("Document text must contain 'Piotr'");
        }
    }
}
