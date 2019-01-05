using System.Threading.Tasks;
using StackExchange.Redis;

public class RedisDatabase : IRedisDatabase
{
    ConnectionMultiplexer _redis = null;
    IDatabase _db = null;

    public RedisDatabase()
    {
        _redis = ConnectionMultiplexer.Connect("redis");
        _db = _redis.GetDatabase();
    }
    
    public string GetBranch(string key)
    {
        return _db.StringGet($"branch-{key}");
    }

    public async Task<string> GetBranchAsync(string key)
    {
        return await _db.StringGetAsync($"branch-{key}");
    }

    public bool SetBranch(string key, string value)
    {
        return _db.StringSet($"branch-{key}", value);
    }

    public async Task<bool> SetBranchAsync(string key, string value)
    {
        return await _db.StringSetAsync($"branch-{key}", value);
    }
}
