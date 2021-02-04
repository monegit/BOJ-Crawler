using System.Security.AccessControl;
using System.Net;
using System;
using System.Collections.Generic;

namespace OJ.Data.Baekjoon
{
    internal class Baekjoon : IOnlineJudge
    {
        Dictionary<string, string> info = new();
        WebClient wc = new();

        internal Baekjoon(string name)
        {
            var document = new HtmlAgilityPack.HtmlDocument();
            var c = new WebClient().DownloadString($"https://www.acmicpc.net/user/{name}");
            document.LoadHtml(c);
            var a = document.DocumentNode.SelectSingleNode("//*[@id='statics']/tbody");

            foreach (var item in a.SelectNodes("tr"))
            {
                info.Add(item.SelectSingleNode("th").InnerText.Trim(), item.SelectSingleNode("td").InnerText.Trim());
            }
        }

        public string GetRank => info["랭킹"];

        public int GetFail => int.Parse(info["틀렸습니다"]);

        public int GetHalfSolved(string name)
        {
            throw new NotImplementedException();
        }

        public int GetSolved(string name)
        {
            throw new NotImplementedException();
        }

        public int GetSolvedAll(string name)
        {
            throw new NotImplementedException();
        }

        public int GetSubmit(string name)
        {
            throw new NotImplementedException();
        }
    }
}