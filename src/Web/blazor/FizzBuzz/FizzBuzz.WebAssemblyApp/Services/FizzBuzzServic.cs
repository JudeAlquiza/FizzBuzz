using FizzBuzz.WebAssemblyApp.Handlers;
using FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers;

namespace FizzBuzz.WebAssemblyApp.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IHandler<Request> _handler;

        public FizzBuzzService()
        {
            _handler = new ValidValueValidatorHandler();
            _handler
                .SetNext(new FizzBuzzValueValidatorHandler())
                .SetNext(new FizzValueValidatorHandler())
                .SetNext(new BuzzValueValidatorHandler());
        }

        public List<KeyValuePair<string?, List<string>>> FizzBuzz(IList<string?> values)
        {          
            var results = new List<KeyValuePair<string?, List<string>>>();

            for (int i = 0; i < values.Count; i++)
            {
                try
                {
                    var request = new Request { ValueText = values[i] };
                    _handler.Handle(request);
                    results.Add(new KeyValuePair<string?, List<string>>(values[i], request.Operations));
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return results;
        }
    }
}
