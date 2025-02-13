namespace Homework14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var top30 = numbers.Top(30).ToArray();

            foreach (var item in top30)
            {
                Console.WriteLine(item);
            }

            var people = new List<Person>
            {
                new Person { Name = "Ivan", Age = 18 },
                new Person { Name = "Petr", Age = 45 },
                new Person { Name = "Alexandr", Age = 31 }
            };

            var topPeopleByAge = people.Top(50, person => person.Age).ToArray();
            
            foreach (var item in topPeopleByAge)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> source, int percent)
        {
            if ((percent > 100) || (percent < 1))
                throw new ArgumentException("percent must be between 1 and 100");

            int count = source.Count();

            int takeCount = (int)Math.Ceiling(count * percent / 100.0);

            return source.OrderByDescending(item => item).Take(takeCount);
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> source, int percent, Func<T, int> selector)
        {
            if ((percent > 100) || (percent < 1))
                throw new ArgumentException("percent must be between 1 and 100");

            int count = source.Count();

            int takeCount = (int)Math.Ceiling(count * percent / 100.0);

            return source.OrderByDescending(selector).Take(takeCount);
        }  
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}