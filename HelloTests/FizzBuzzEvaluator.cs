using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloTests
{
    public class FizzBuzzEvaluator
    {
        private readonly IExportable Exporter;

        public FizzBuzzEvaluator(IExportable exporter)
        {
            if (exporter != null)
            {
                Exporter = exporter;
            }
            else
            {
                throw new ArgumentNullException("FizzBuzzEvaluator missing exporter");
            }
        }

        private bool DivisibleByThree(int x) => (x % 3 == 0);

        private bool DivisibleByFive(int x) => (x % 5 == 0);

        private bool DivisibleByThreeAndFive(int x) => DivisibleByThree(x) && DivisibleByFive(x);

        public IEnumerable<int> FilterByBuzz(IEnumerable<int> numbersToEvaluate) =>
            numbersToEvaluate.Where(DivisibleByFive);

        public IEnumerable<int> FilterByFizz(IEnumerable<int> numbersToEvaluate) =>
            numbersToEvaluate.Where(DivisibleByThree);

        public IEnumerable<int> FilterByFizzBuzz(IEnumerable<int> numbersToEvaluate) =>
            numbersToEvaluate.Where(DivisibleByThree).Where(DivisibleByFive);

        private List<FizzBuzzResult> MapToResult(IEnumerable<int> numbersToEvaluate)
        {
            var result = new List<FizzBuzzResult>();

            foreach (int number in numbersToEvaluate)
            {
                if (DivisibleByThreeAndFive(number))
                {
                    result.Add(new FizzBuzzResult(number, FizzBuzzState.FizzBuzz));
                }
                else if (DivisibleByThree(number))
                {
                    result.Add(new FizzBuzzResult(number, FizzBuzzState.Fizz));
                }
                else if (DivisibleByFive(number))
                {
                    result.Add(new FizzBuzzResult(number, FizzBuzzState.Buzz));
                }
            }
            return result;
        }

        public string ExportAllOutput(IEnumerable<int> numbersToEvaluate) =>
            Exporter.Export(MapToResult(numbersToEvaluate));

        public string ExportFizzOutput(IEnumerable<int> numbersToEvaluate) =>
            Exporter.Export(MapToResult(FilterByFizz(numbersToEvaluate)));

        public string ExportBuzzOutput(IEnumerable<int> numbersToEvaluate) =>
            Exporter.Export(MapToResult(FilterByBuzz(numbersToEvaluate)));

        public string ExportFizzBuzzOutput(IEnumerable<int> numbersToEvaluate) =>
            Exporter.Export(MapToResult(FilterByBuzz(numbersToEvaluate)));
    }
}