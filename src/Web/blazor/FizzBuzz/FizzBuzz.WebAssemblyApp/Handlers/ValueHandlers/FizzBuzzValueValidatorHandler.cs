namespace FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers
{
    public class FizzBuzzValueValidatorHandler : Handler<Request>
    {
        public override void Handle(Request request)
        {
            if (!request.ValueNum.HasValue)
            {
                throw new ArgumentException($"{request.ValueText} is not a valid number");
            }

            if (request.ValueNum.Value % 15 == 0)
            {
                request.Operations.Clear();
                request.Operations.Add("FizzBuzz");
                return;
            }

            base.Handle(request);
        }
    }
}
