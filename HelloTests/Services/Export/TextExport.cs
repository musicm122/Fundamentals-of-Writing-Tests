using System.Collections.Generic;
using System.Text;

namespace HelloTests.Services.Implementation
{
    public class TextExport: IExportable
    {
        public string Export(IEnumerable<FizzBuzzResult> results)
        {
            var sb = new StringBuilder();
            foreach (FizzBuzzResult result in results)
            {
                sb.AppendLine($"{result.Value} = ${result.State}");
            }
            return sb.ToString();
        }
    }
}
