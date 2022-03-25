namespace FizzBuzz.WebAssemblyApp.Services
{
    public interface IFizzBuzzService
    {
        List<KeyValuePair<string?, List<string>>> FizzBuzz(IList<string?> values);
    }
}
