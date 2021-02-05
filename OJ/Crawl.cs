using System.Reflection;
using System.Security.AccessControl;
using System;
using OJ.Data;
using OJ.Data.Baekjoon;

namespace OJ
{
    public class Crawl : IOnlineJudge
    {
        object type;

        public Crawl(OJType? type, string name)
        {
            switch (type)
            {
                case OJType.Baekjoon:
                    this.type = new Baekjoon(name);
                    break;
            }
        }

        public string GetRank => (type as IOnlineJudge).GetRank;

        public string GetSolved => (type as IOnlineJudge).GetSolved;

        public string GetHalfSolved => (type as IOnlineJudge).GetHalfSolved;

        public string GetSubmit => (type as IOnlineJudge).GetSubmit;

        public string GetSolvedAll => (type as IOnlineJudge).GetSolvedAll;

        public string GetFail => (type as IOnlineJudge).GetFail;
    }
}