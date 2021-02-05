using System;
using OJ;
using OJ.Data.Baekjoon;

namespace BOJ_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var oj = new Crawl(OJType.Baekjoon, name);

            Console.WriteLine($"{KeyType.Rank}: {oj.GetRank}");
            Console.WriteLine($"{KeyType.Fail}: {oj.GetFail}");
            Console.WriteLine($"{KeyType.Solved}: {oj.GetSolved}");
            Console.WriteLine($"{KeyType.SolvedAll}: {oj.GetSolvedAll}");
            Console.WriteLine($"{KeyType.Submit}: {oj.GetSubmit}");
            Console.WriteLine($"{KeyType.HalfSolved}: {oj.GetHalfSolved}");
        }
    }
}
