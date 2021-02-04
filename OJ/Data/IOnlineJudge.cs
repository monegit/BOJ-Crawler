namespace OJ.Data
{
    internal interface IOnlineJudge
    {
        string GetRank{get;}
        int GetSolved(string name);
        int GetHalfSolved(string name);
        int GetSubmit(string name);
        int GetSolvedAll(string name);
        int GetFail{get;}
    }
}