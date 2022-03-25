using FizzBuzz.WebAssemblyApp.Handlers;
using FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers;
using System;
using System.Linq;
using Xunit;

namespace FizzBuzz.WebAssemblyApp.UnitTests.Handlers.ValueHandlers
{
    public class BuzzValueValidatorHandlerTests
    {
        [Fact]
        public void HandleRequestWithNullValueNum_ThrowArgumentException()
        {
            // arrange
            var handler = new BuzzValueValidatorHandler();
            var request = new Request { ValueNum = null };

            // act // assert
            Assert.Throws<ArgumentException>(() => handler.Handle(request));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(25)]
        [InlineData(35)]
        [InlineData(45)]
        [InlineData(50)]
        public void HandleRequestWithValueNumDivisibleBy5_AddBuzzToOperationsProp(int valueNum)
        {
            // arrange
            var handler = new BuzzValueValidatorHandler();
            var request = new Request { ValueNum = valueNum };

            // act
            handler.Handle(request);

            // assert
            Assert.True(request.Operations.Count == 1);
            Assert.True(request.Operations.First() == "Buzz");
        }

        [Theory]
        [InlineData(7)]
        [InlineData(11)]
        [InlineData(16)]
        [InlineData(27)]
        [InlineData(37)]
        public void HandleRequestWithValueNumNotDivisibleBy5_AddBuzzToOperationsProp(int valueNum)
        {
            // arrange
            var handler = new BuzzValueValidatorHandler();
            var request = new Request { ValueNum = valueNum };

            // act
            handler.Handle(request);

            // assert
            Assert.Contains($"Divided {request.ValueNum.Value} by 5", request.Operations);
        }
    }
}
