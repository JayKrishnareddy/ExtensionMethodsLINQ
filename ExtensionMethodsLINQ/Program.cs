using System;

namespace ExtensionMethodsLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var words = new List<string> { "apple", "Banana", "Cherry", "date" };

            var result = words.CaseInsensitiveContains("b");

            Console.WriteLine(result);

            // Result: Banana

            var numbers = new List<decimal> { 2, 3, 4 };

            var response = numbers.Product();

            // Result: 24

            var persons = new List<Person>
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 },
                new Person { Name = "Charlie", Age = 25 }
            };

            var res = persons.FilterByProperty(p => p.Age, 25);

            Console.WriteLine(res);
            // Result: Alice, 25 and Charlie, 25

        }
    }


    public static class LinqExtensions
    {
        public static IEnumerable<T> FilterByProperty<T, TValue>(
            this IEnumerable<T> source,
            Func<T, TValue> propertySelector,
            TValue value)
        {
            return source.Where(item => propertySelector(item).Equals(value));
        }
        public static IEnumerable<string> CaseInsensitiveContains(
            this IEnumerable<string> source,
            string substring)
        {
            return source.Where(item => item.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public static string ToUpperCase(this string input)
        {
            return input.ToUpper();
        }
        public static decimal Product(this IEnumerable<decimal> source)
        {
            return source.Aggregate((current, next) => current * next);
        }
    }

    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}