using System;
using FluentValidation;

namespace ValidationChainOfResponsibility.ValidationHandlers
{
    public abstract class ValidationHandler<TValidator, TEntity> : IValidationHandler<TEntity>
        where TEntity : class
        where TValidator : AbstractValidator<TEntity>, new()
    {
        protected IValidationHandler<TEntity> SuccessorHandler { get; private set; }

        protected  ValidationHandler() { }

        protected ValidationHandler(IValidationHandler<TEntity> successorHandler)
        {
            if (successorHandler == null)
            {
                throw new ArgumentNullException("successorHandler");
            }

            SuccessorHandler = successorHandler;
        }

        public ValidationHandlerResult Validate(TEntity entity)
        {
            var validator = new TValidator();
            var result = validator.Validate(entity);

            if (result.IsValid && SuccessorHandler != null)
            {
                return SuccessorHandler.Validate(entity);
            }
            
            return new ValidationHandlerResult
            {
                ValidationResult = result,
                Validator = typeof(TValidator)
            };
        }
    }
}
