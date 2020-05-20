using System.Collections.Generic;
using System.Net;

namespace BOJ_Crawler.Information
{
    public class Problem
    {
        public List<string> problem = new List<string>();
        public List<string> language = new List<string>();
        public List<string> date = new List<string>();
        string request = string.Empty;

        public Problem(string userName)
        {
            request = new WebClient().DownloadString(
                "https://www.acmicpc.net/status?user_id=" + userName + "&result_id=4");

            var item = new List<string>();
            item = ParseTableItem(ParseHttpTable(request));
            
            for (int i =0;i<=item.Count-1;i++)
                SolveProblem(item[i]);
        }

        private string ParseHttpTable(string http)
        {
            return http.Split("table-responsive")[1].Split("</div>")[0]
                .Split("<tbody>")[1].Split("</tbody>")[0];
        }

        private List<string> ParseTableItem(string table)
        {
            var child = new List<string>();

            for (int i = 1; i <= table.Split("<tr").Length - 1; i++)
                child.Add(table.Split("<tr")[i].Split("</tr>")[0]);
            return child;
        }

        private void SolveProblem(string item)
        {
            var child = new List<string>();
            
            // array index 0 -> problem name, number
            problem.Add(item.Split("<td")[3].Split("</td>")[0]
                .Split("title=\"")[1].Split("\"")[0]
                + " (" +
                item.Split("<a href=\"/problem/")[1].Split("\"")[0]
                + ")");
            
            // array index 1 -> used language
            language.Add(item.Split("<td>")[4].Split("</td>")[0]);

            // array index 2 -> solved date time
            date.Add(item.Split("<td>")[6].Split("</td>")[0]
                .Split("title=\"")[1].Split("\"")[0]);
                
        }
    }
}