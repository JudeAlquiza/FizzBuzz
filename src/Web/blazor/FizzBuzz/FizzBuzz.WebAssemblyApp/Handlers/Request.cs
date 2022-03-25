namespace FizzBuzz.WebAssemblyApp.Handlers
{
    public class Request
    {
        public string? ValueText { get; set; }
        public int? ValueNum { get; set; }
        public List<string> Operations { get; set; } = new List<string>();
    }
}
