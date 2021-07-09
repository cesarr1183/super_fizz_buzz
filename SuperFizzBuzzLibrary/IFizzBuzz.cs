using System.Collections.Generic;

namespace SuperFizzBuzz.Library
{
    public interface IFizzBuzz
    {
        IEnumerable<string> GetFizzBuzz(int start, int end, IEnumerable<Token> tokens);
        IEnumerable<string> GetFizzBuzz(IEnumerable<int> sequence, IEnumerable<Token> tokens);
    }
}
