using ValidationChainOfResponsibility;
using ValidationChainOfResponsibility.Validation;
using FluentAssertions;
using Xunit;

namespace ValidationChainOfResponsibilityTests
{
    public class ValidationChainOfResponsibilityWorkflowTests
    {
        [Fact]
        public void when_document_empty_then_content_mandatory_validator_flags()
        {
            var chainOfHandlers = new DocumentChainOfHandlersFactory().Create();

            var emptyDocument = new Document {Id = 2, Text = string.Empty};

            var result = chainOfHandlers.Validate(emptyDocument);

            result.Validator.Should().Be(typeof (DocumentTextRequiredValidator));
            result.ValidationResult.IsValid.Should().BeFalse();
            result.ValidationResult.Errors[0].PropertyName.Should().Be("Text");
        }

        [Fact]
        public void when_document_not_empty_but_too_short_then_length_validator_flags()
        {
            var chainOfHandlers = new DocumentChainOfHandlersFactory().Create();

            var document = new Document {Id = 1, Text = "bababab"};

            var result = chainOfHandlers.Validate(document);

            result.Validator.Should().Be(typeof(DocumentTextLengthValidator));
            result.ValidationResult.IsValid.Should().BeFalse();
            result.ValidationResult.Errors[0].PropertyName.Should().Be("Text");
        }

        [Fact]
        public void when_document_content_invalid_then_content_validator_flags()
        {
            var chainOfHandlers = new DocumentChainOfHandlersFactory().Create();

            var document = new Document { Id = 1, Text = new string('*', 1001) };

            var result = chainOfHandlers.Validate(document);

            result.Validator.Should().Be(typeof(DocumentTextContentValidator));
            result.ValidationResult.IsValid.Should().BeFalse();
            result.ValidationResult.Errors[0].PropertyName.Should().Be("Text");
        }

        [Fact]
        public void when_document_valid_then_no_validator_flags()
        {
            var chainOfHandlers = new DocumentChainOfHandlersFactory().Create();

            var document = new Document { Id = 1, Text = new string('*', 1001) + "Piotr" };

            var result = chainOfHandlers.Validate(document);

            result.Validator.Should().Be(typeof(DocumentTextContentValidator));
            result.ValidationResult.IsValid.Should().BeTrue();
            result.ValidationResult.Errors.Should().BeEmpty();
        }
    }
}
