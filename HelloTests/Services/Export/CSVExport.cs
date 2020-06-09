using System;
using System.Collections.Generic;
using System.Text;

namespace HelloTests.Services.Implementation
{
    public class CSVExport : IExportable
    {
        public string Export(IEnumerable<FizzBuzzResult> results)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Value,State");
            foreach (FizzBuzzResult result in results)
            {
                sb.AppendLine($"{result.Value},${result.State}");
            }
            return sb.ToString();
        }
    }
}
