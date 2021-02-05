namespace OJ.Data
{
    internal interface IOnlineJudge
    {
        string GetRank { get; }
        string GetSolved { get; }
        string GetHalfSolved { get; }
        string GetSubmit { get; }
        string GetSolvedAll { get; }
        string GetFail { get; }
    }
}