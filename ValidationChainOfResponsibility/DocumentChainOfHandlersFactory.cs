using ValidationChainOfResponsibility.ValidationHandlers;

namespace ValidationChainOfResponsibility
{
    public class DocumentChainOfHandlersFactory : IChainOfHandlersFactory<Document>
    {
        public IValidationHandler<Document> Create()
        {
            return 
                new DocumentTextRequiredValidationHandler(
                    new DocumentTextLengthValidationHandler(
                        new DocumentTextContentValidationHandler()));
        }
    }
}
