using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace BOJ_Discord_Bot.BOJ_Crawler.Information
{
    public class User
    {
        private string request = string.Empty;

        public User(string userName)
        {
            request = new WebClient().DownloadString(
                "https://www.acmicpc.net/user/" + userName);
        }

        public string GetRanking()
        {
            return InfoTableList(InfoTable(request))[0]
                .Split("<td>")[1].Split("</td>")[0];
        }

        public string GetSolvedProblem()
        {
            return InfoTableList(InfoTable(request))[1]
                .Split("<td>")[1].Split("<td>")[0];
        }


        private string RemoveLink(string content)
        {
            Regex regex = new Regex("<a[^>]*>(.*?)</a>",
                RegexOptions.IgnoreCase);
            return null; //content.Split("<a href")[1].Split(">")[0];
            
            string _() => regex.Match(content).Success ? return null: return null;
        
        }

        private string InfoTable(string request)
        {
            return request.Split("<table id = \"statics\"")[1]
                .Split("</table>")[0];
        }

        private List<string> InfoTableList(string table)
        {
            List<string> list = new List<string>();

            /*
                [0] ranking
                [1] solved problems count
                [2] problems submit count
                [3] success count
                [4] failed count
                [5] timeout count
                [6] memory out count
                [7] output exceeded count
                [8] runtime error count
                [9] compile error count
                [10] college or company name
            */
            for (int i = 1; i <= table.Split("<tr").Length - 1; i++)
            {
                list.Add(table.Split("<tr")[i]
                    .Split("</tr>")[0].Trim() // content
                    .Replace("\t", "")); // remove space letter
            }

            return list;
        }
    }
}