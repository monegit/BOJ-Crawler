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
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[1]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetSubmit()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[2]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetSuccess()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[3]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetFailed()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[4]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetTimeout()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[5]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetMemoryOut()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[6]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetOutputExceeded()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[7]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetRuntimeError()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[8]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetCompileError()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[9]
                .Split("<td>")[1].Split("</td>")[0]);
        }

        public string GetOrganization()
        {
            return RemoveHTML(
                InfoTableList(
                    InfoTable(request)
                )[10]
                .Split("<td>")[1].Split("</td>")[0]);
        }



        private string RemoveHTML(string content)
        {
            return Regex.Replace(content, "<.*?>|&.*?;", string.Empty);
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
                    .Replace("\t", string.Empty)
                    .Replace("\n", string.Empty)); // remove space letter
            }

            return list;
        }
    }
}