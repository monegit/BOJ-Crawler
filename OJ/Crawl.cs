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

        public int GetFail => (type as IOnlineJudge).GetFail;

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