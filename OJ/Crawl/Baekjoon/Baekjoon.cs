using System.Collections.Generic;
using System.Net;

namespace OJ.Data.Crawl
{
    public class Baekjoon
    {
        internal static Dictionary<string, string> GetDictionary(string name)
        {
            var data = new Dictionary<string, string>();
            var document = new HtmlAgilityPack.HtmlDocument();
            var wc = new WebClient().DownloadString($"https://www.acmicpc.net/user/{name}");
            document.LoadHtml(wc);
            var table = document.DocumentNode.SelectSingleNode("//*[@id='statics']/tbody");

            foreach (var item in table.SelectNodes("tr"))
            {
                data.Add(item.SelectSingleNode("th").InnerText.Trim(), item.SelectSingleNode("td").InnerText.Trim());
            }

            return data;
        }
    }
}