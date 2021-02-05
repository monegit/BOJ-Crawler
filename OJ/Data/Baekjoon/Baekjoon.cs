using System.Collections.Generic;

namespace OJ.Data.Baekjoon
{
    internal class Baekjoon : IOnlineJudge
    {
        private Dictionary<string, string> data = new();

        internal Baekjoon(string name)
        {
            data = Crawl.Baekjoon.GetDictionary(name);
        }

        private string GetValue(string key)
        {
            return data.ContainsKey(key) ? data[key] : "정보 없음";
        }

        public string GetRank => GetValue(KeyType.Rank);

        public string GetSolved => GetValue(KeyType.Solved);

        public string GetHalfSolved => GetValue(KeyType.HalfSolved);

        public string GetSubmit => GetValue(KeyType.Submit);

        public string GetSolvedAll => GetValue(KeyType.SolvedAll);

        public string GetFail => GetValue(KeyType.Fail);
    }
}