using FizzBuzz.WebAssemblyApp.Handlers;
using FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers;
using System.Linq;
using Xunit;

namespace FizzBuzz.WebAssemblyApp.UnitTests.Handlers.ValueHandlers
{
    public class ValidValueValidatorHandlerTests
    {
        [Fact]
        public void HandleRequestWithNullValueText_AddInvalidItemToOperationsProp()
        {
            // arrange
            var handler = new ValidValueValidatorHandler();
            var request = new Request { ValueText = null };

            // act
            handler.Handle(request);

            // assert
            Assert.True(request.Operations.Count == 1);
            Assert.True(request.Operations.First() == "Invalid Item");
        }

        [Theory]
        [InlineData("A")]
        [InlineData("b")]
        [InlineData("aB")]
        [InlineData("ABc")]
        [InlineData("abCd")]
        public void HandleRequestWithInvalidValueText_AddInvalidItemToOperationsProp(string invalidValueText)
        {
            // arrange
            var handler = new ValidValueValidatorHandler();
            var request = new Request { ValueText = invalidValueText };

            // act
            handler.Handle(request);

            // assert
            Assert.True(request.Operations.Count == 1);
            Assert.True(request.Operations.First() == "Invalid Item");
        }

        [Theory]
        [InlineData("1")]
        [InlineData("3")]
        [InlineData("5")]
        [InlineData("15")]
        [InlineData("24")]
        public void HandleRequestWithValidValueText_SetValueNumProperty(string validValueText)
        {
            // arrange
            var handler = new ValidValueValidatorHandler();
            var request = new Request { ValueText = validValueText };

            // act
            handler.Handle(request);

            // assert
            Assert.True(request.ValueNum == int.Parse(request.ValueText));
        }
    }
}
