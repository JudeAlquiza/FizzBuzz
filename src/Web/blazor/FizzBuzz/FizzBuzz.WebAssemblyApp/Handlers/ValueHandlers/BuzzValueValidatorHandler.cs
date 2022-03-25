namespace FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers
{
    public class BuzzValueValidatorHandler : Handler<Request>
    {
        public override void Handle(Request request)
        {
            if (!request.ValueNum.HasValue)
            {
                throw new ArgumentException($"{request.ValueText} is not a valid number");
            }

            if (request.ValueNum.Value % 5 == 0)
            {
                request.Operations.Clear();
                request.Operations.Add("Buzz");
                return;
            }

            request.Operations.Add($"Divided {request.ValueNum.Value} by 5");
            base.Handle(request);
        }
    }
}
