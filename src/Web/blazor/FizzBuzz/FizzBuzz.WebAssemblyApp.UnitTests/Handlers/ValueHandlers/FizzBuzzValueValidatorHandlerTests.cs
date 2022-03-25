using FizzBuzz.WebAssemblyApp.Handlers;
using FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers;
using System;
using System.Linq;
using Xunit;

namespace FizzBuzz.WebAssemblyApp.UnitTests.Handlers.ValueHandlers
{
    public class FizzBuzzValueValidatorHandlerTests
    {
        [Fact]
        public void HandleRequestWithNullValueNum_ThrowArgumentException()
        {
            // arrange
            var handler = new FizzBuzzValueValidatorHandler();
            var request = new Request { ValueNum = null };

            // act // assert
            Assert.Throws<ArgumentException>(() => handler.Handle(request));
        }


        [Theory]
        [InlineData(15)]
        [InlineData(45)]
        [InlineData(60)]
        [InlineData(75)]
        [InlineData(90)]
        public void HandleRequestWithValueNumDivisibleBy15_AddFizzBuzzToOperationsProp(int valueNum)
        {
            // arrange
            var handler = new FizzBuzzValueValidatorHandler();
            var request = new Request { ValueNum = valueNum };

            // act
            handler.Handle(request);

            // assert
            Assert.True(request.Operations.Count == 1);
            Assert.True(request.Operations.First() == "FizzBuzz");
        }
    }
}
