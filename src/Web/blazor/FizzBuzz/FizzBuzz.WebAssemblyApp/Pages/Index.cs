namespace FizzBuzz.WebAssemblyApp.Pages
{
    public partial class Index
    {
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
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i] == null)
                {
                    Results.Add(new KeyValuePair<string?, List<string>>(Values[i], new List<string> { "Invalid Item" }));
                    continue;
                }

                if (int.TryParse(Values[i], out int number))
                {
                    var operations = new List<string>();

                    if (number % 15 == 0)
                    {
                        Results.Add(new KeyValuePair<string?, List<string>>(Values[i], new List<string> { "FizzBuzz" }));
                        continue;
                    }
                    
                    if (number % 3 == 0)
                    {
                        Results.Add(new KeyValuePair<string?, List<string>>(Values[i], new List<string> { "Fizz" }));
                        continue;
                    }
                    else 
                    {
                        operations.Add($"Divided {number} by 3");
                    }

                    if (number % 5 == 0)
                    {
                        Results.Add(new KeyValuePair<string?, List<string>>(Values[i], new List<string> { "Buzz" }));
                        continue;
                    }
                    else
                    {
                        operations.Add($"Divided {number} by 5");
                    }

                    Results.Add(new KeyValuePair<string?, List<string>>(Values[i], operations));
                    continue;
                }
                else 
                {
                    Results.Add(new KeyValuePair<string?, List<string>>(Values[i], new List<string> { "Invalid Item" }));
                    continue;
                }
            }
        }

        public void Reset()
        {
            Values = new List<string?>();
            Results = new List<KeyValuePair<string?, List<string>>>();
        }
    }
}
