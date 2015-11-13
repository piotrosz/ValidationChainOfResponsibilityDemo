using ValidationChainOfResponsibility.Validation;

namespace ValidationChainOfResponsibility.ValidationHandlers
{
    public class DocumentTextRequiredValidationHandler : ValidationHandler<DocumentTextRequiredValidator, Document>
    {
        public DocumentTextRequiredValidationHandler(IValidationHandler<Document> successorHandler) : base(successorHandler)
        {
        }
    }
}
