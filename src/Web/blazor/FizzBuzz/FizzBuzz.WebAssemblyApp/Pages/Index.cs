using FizzBuzz.WebAssemblyApp.Services;
using Microsoft.AspNetCore.Components;

namespace FizzBuzz.WebAssemblyApp.Pages
{
    public partial class Index
    {
        [Inject]
        public IFizzBuzzService FizzBuzzService { get; set; } = null!;

        public List<string?> Values { get; set; } = new List<string?>();
        public List<KeyValuePair<string?, List<string>>> Results { get; set; } = new List<KeyValuePair<string?, List<string>>>();

        public void AddValue()
        {
            Values.Add(null);
            StateHasChanged();
        }

        public void RemoveInteger(int index)
        {
            Values.RemoveAt(index);
            StateHasChanged();
        }

        public void FizzBuzz()
        {
            Results = FizzBuzzService.FizzBuzz(Values);
        }

        public void Reset()
        {
            Values = new List<string?>();
            Results = new List<KeyValuePair<string?, List<string>>>();
        }
    }
}
