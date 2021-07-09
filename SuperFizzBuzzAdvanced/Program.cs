using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SuperFizzBuzz.Library;

namespace SuperFizzBuzz.SuperFizzBuzzAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                    .AddScoped<IFizzBuzz, Library.SuperFizzBuzz>()
                    .BuildServiceProvider();

            var tokenList = new List<Token>()
                {new Token() {DivisionBy = 3, Output = "Fizz"}, new Token() {DivisionBy = 7, Output = "Buzz"}, new Token() {DivisionBy = 38, Output = "Bazz"}};

            var superFizzBuzzService = serviceProvider.GetService<IFizzBuzz>();
            foreach (var result in superFizzBuzzService.GetFizzBuzz(-12, 145, tokenList))
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
