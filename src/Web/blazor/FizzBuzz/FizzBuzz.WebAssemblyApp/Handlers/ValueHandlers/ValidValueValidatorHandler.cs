namespace FizzBuzz.WebAssemblyApp.Handlers.ValueHandlers
{
    public class ValidValueValidatorHandler : Handler<Request>
    {
        public override void Handle(Request request)
        {
            if (string.IsNullOrEmpty(request.ValueText) || !int.TryParse(request.ValueText, out int number))
            {
                request.Operations.Add("Invalid Item");
                return;
            }

            request.ValueNum = number;
            base.Handle(request);
        }
    }
}
