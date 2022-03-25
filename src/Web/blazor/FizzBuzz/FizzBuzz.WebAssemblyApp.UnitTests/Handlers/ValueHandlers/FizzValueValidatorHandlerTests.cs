using FizzBuzz.WebAssemblyApp.Handlers;
using FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers;
using System;
using System.Linq;
using Xunit;

namespace FizzBuzz.WebAssemblyApp.UnitTests.Handlers.ValueHandlers
{
    public class FizzValueValidatorHandlerTests
    {
        [Fact]
        public void HandleRequestWithNullValueNum_ThrowArgumentException()
        {
            // arrange
            var handler = new FizzValueValidatorHandler();
            var request = new Request { ValueNum = null };

            // act // assert
            Assert.Throws<ArgumentException>(() => handler.Handle(request));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(12)]
        [InlineData(24)]
        [InlineData(33)]
        [InlineData(51)]
        public void HandleRequestWithValueNumDivisibleBy3_AddFizzToOperationsProp(int valueNum)
        {
            // arrange
            var handler = new FizzValueValidatorHandler();
            var request = new Request { ValueNum = valueNum };

            // act
            handler.Handle(request);

            // assert
            Assert.True(request.Operations.Count == 1);
            Assert.True(request.Operations.First() == "Fizz");
        }

        [Theory]
        [InlineData(7)]
        [InlineData(11)]
        [InlineData(16)]
        [InlineData(29)]
        [InlineData(37)]
        public void HandleRequestWithValueNumNotDivisibleBy3_AddFizzToOperationsProp(int valueNum)
        {
            // arrange
            var handler = new FizzValueValidatorHandler();
            var request = new Request { ValueNum = valueNum };

            // act
            handler.Handle(request);

            // assert
            Assert.Contains($"Divided {request.ValueNum.Value} by 3", request.Operations);
        }
    }
}
