using System;
using OJ;

namespace BOJ_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var oj = new Crawl(OJType.Baekjoon, "spy");
            
            Console.WriteLine($"랭킹: {oj.GetRank}");
            Console.WriteLine($"틀린 횟수: {oj.GetFail}");
        }
    }
}
