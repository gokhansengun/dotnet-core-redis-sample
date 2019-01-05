using System.Threading.Tasks;

public interface IRedisDatabase
{
    string GetBranch(string key);
    Task<string> GetBranchAsync(string key);
    bool SetBranch(string key, string value);
    Task<bool> SetBranchAsync(string key, string value);
}
