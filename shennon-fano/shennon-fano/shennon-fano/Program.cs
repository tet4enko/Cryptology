using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shennon_fano
{
    class Program
    {


        static Dictionary<Char, String> codes = new Dictionary<char, String>();
        static Dictionary<Char, int> dict = new Dictionary<char, int>();

        static void Go(String input, String code)
        {
            if (input.Length == 1)
            {
                codes[input[0]] = code;
            }
            else
            {

            }
        }


        static void Main(string[] args)
        {
            String input = Console.ReadLine(), alphabet = "";


            for (int i = 97; i < 123; i++) { alphabet += Convert.ToChar(i); dict[Convert.ToChar(i)] = 0; }
            for (int i = 0; i < input.Length; i++) dict[input[i]]++;

            List<int> testList = new List<int>();

            for (int i = 0; i < 1000; ++i)
            {
                testList.Add(1);
            }

            Console.WriteLine(SubsetSum.Find(testList, 1000));

           


            Console.ReadKey();
        }


        static class SubsetSum
        {
            private static Dictionary<int, bool> memo;
            private static Dictionary<int, KeyValuePair<int, int>> prev;

            static SubsetSum()
            {
                memo = new Dictionary<int, bool>();
                prev = new Dictionary<int, KeyValuePair<int, int>>();
            }

            public static bool Find(List<int> inputArray, int sum)
            {
                memo.Clear();
                prev.Clear();

                memo[0] = true;
                prev[0] = new KeyValuePair<int, int>(-1, 0);

                for (int i = 0; i < inputArray.Count; ++i)
                {
                    int num = inputArray[i];
                    for (int s = sum; s >= num; --s)
                    {
                        if (memo.ContainsKey(s - num) && memo[s - num] == true)
                        {
                            memo[s] = true;

                            if (!prev.ContainsKey(s))
                            {
                                prev[s] = new KeyValuePair<int, int>(i, num);
                            }
                        }
                    }
                }

                return memo.ContainsKey(sum) && memo[sum];
            }

            public static IEnumerable<int> GetLastResult(int sum)
            {
                while (prev[sum].Key != -1)
                {
                    yield return prev[sum].Key;
                    sum -= prev[sum].Value;
                }
            }
        }
    }
}
