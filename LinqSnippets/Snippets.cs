using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            var carList = from car in cars select car;
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var car in audiList)
            {
                Console.WriteLine(car);
            }

        }

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var processedNumberList =
                numbers.Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);

        }

        static public void SearchEamples()
        {
            List<string> textLis = new List<string>
            {
                "a",
                "bx",
                "as",
                "f",
                "h",
                "fh",
                "jk",
                "vb",
                "yt",
            };

            var first = textLis.First();

            var cText = textLis.First(text => text.Equals("c"));

            var jText = textLis.First(text => text.Contains("j"));

            var firstzorder = textLis.FirstOrDefault(text => text.Contains("z"));

            var lastzorder = textLis.LastOrDefault(text => text.Contains("z"));

            var uniqueElements = textLis.Single();

            var uniqueDefaultElements = textLis.SingleOrDefault();
        }

        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultPerPage)
        {
            int startIndex = (pageNumber - 1) * resultPerPage;
            return collection.Skip(startIndex).Take(resultPerPage);
        }


    }
}