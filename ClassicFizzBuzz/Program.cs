using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SuperFizzBuzz.Library;

namespace SuperFizzBuzz.ClassicFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IFizzBuzz, Library.SuperFizzBuzz>()
                .BuildServiceProvider();

            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 3, Output = "Fizz"}, new Token() {DivisionBy = 5, Output = "Buzz"}};

            var superFizzBuzzService = serviceProvider.GetService<IFizzBuzz>();
            foreach (var result in superFizzBuzzService.GetFizzBuzz(1, 100, tokenList))
            {
                Console.WriteLine(result);
            }
            
            Console.ReadKey();
        }
    }
}
