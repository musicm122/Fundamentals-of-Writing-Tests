using HelloTests.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloTests
{
    internal class Program
    {
        private static void Main()
        {
            //Random rgn = new Random();
            IEnumerable<int> numbers = Enumerable.Range(1, 20);

            var csvEvaluator = new FizzBuzzEvaluator(new CSVExport());
            var textEvaluator = new FizzBuzzEvaluator(new TextExport());
            var jsonEvaluator = new FizzBuzzEvaluator(new JsonExport());

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Text Export");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(textEvaluator.ExportAllOutput(numbers));
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("CSV Export");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(csvEvaluator.ExportAllOutput(numbers));
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("JSON Export");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(jsonEvaluator.ExportAllOutput(numbers));
            Console.WriteLine("--------------------------------------");
        }
    }
}