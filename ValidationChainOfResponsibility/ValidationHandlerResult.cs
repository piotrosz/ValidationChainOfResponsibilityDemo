using System;
using FluentValidation.Results;

namespace ValidationChainOfResponsibility
{
    public class ValidationHandlerResult
    {
        public Type Validator { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
