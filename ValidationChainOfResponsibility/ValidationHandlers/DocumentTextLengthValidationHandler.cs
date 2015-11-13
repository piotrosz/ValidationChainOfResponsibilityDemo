using ValidationChainOfResponsibility.Validation;

namespace ValidationChainOfResponsibility.ValidationHandlers
{
    public class DocumentTextLengthValidationHandler : ValidationHandler<DocumentTextLengthValidator, Document>
    {
        public DocumentTextLengthValidationHandler(IValidationHandler<Document> successorHandler) : base(successorHandler)
        {
        }
    }
}
