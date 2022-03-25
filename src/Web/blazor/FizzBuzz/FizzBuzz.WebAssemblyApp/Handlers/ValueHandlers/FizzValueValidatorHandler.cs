namespace FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers
{
    public class FizzValueValidatorHandler : Handler<Request>
    {
        public override void Handle(Request request)
        {
            if (!request.ValueNum.HasValue)
            {
                throw new ArgumentException($"{request.ValueText} is not a valid number");
            }

            if (request.ValueNum.Value % 3 == 0)
            {
                request.Operations.Clear();
                request.Operations.Add("Fizz");
                return;
            }

            request.Operations.Add($"Divided {request.ValueNum.Value} by 3");
            base.Handle(request);
        }
    }
}
