using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFizzBuzz.Library
{
    public class SuperFizzBuzz : IFizzBuzz
    {
        public IEnumerable<string> GetFizzBuzz(IEnumerable<int> sequence, IEnumerable<Token> tokens)
        {
            if (sequence == null)
                throw new ArgumentException(nameof(sequence));

            if (tokens == null)
                throw new ArgumentException(nameof(tokens));

            var myStringBuilder = new StringBuilder();
            foreach (var value in sequence)
            {
                foreach (var token in tokens)
                {
                    myStringBuilder.Append(GetFizzBuzzResult(value, token.DivisionBy, token.Output));
                }

                yield return string.IsNullOrEmpty(myStringBuilder.ToString()) ? value.ToString() : myStringBuilder.ToString();
                myStringBuilder.Clear();
            }
        }

        public IEnumerable<string> GetFizzBuzz(int start, int end, IEnumerable<Token> tokens)
        {
            int lowerIndex, upperIndex;
            bool reverseFlag = default;
            if (start <= end)
            {
                lowerIndex = start;
                upperIndex = end;
            }
            else
            {
                lowerIndex = end;
                upperIndex = start;
                reverseFlag = true;
            }

            return GetFizzBuzz(GenerateSequence(lowerIndex, upperIndex, reverseFlag), tokens);
        }

        private IEnumerable<int> GenerateSequence(int lower, int upper, bool reverse = false)
        {
            if(!reverse){
                for (var i = lower; i <= upper; i++)
                    yield return i;
            }
            else {
                for (var i = upper; i >= lower; i--)
                    yield return i;
            }
            
        }

        private string GetFizzBuzzResult(int value, int divisionBy, string output)
        {
            return value % divisionBy == 0 ? output : string.Empty;
        }
    }
}
