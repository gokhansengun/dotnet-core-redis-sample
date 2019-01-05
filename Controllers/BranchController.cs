using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace dotnet_core_redis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IRedisDatabase _redisDatabase;

        public BranchController(IRedisDatabase redisDatabase)
        {
            _redisDatabase = redisDatabase;
        }

        // [HttpGet("{key}")]
        // public async Task<ActionResult<string>> Get(string key)
        // {
        //     return await _redisDatabase.GetBranchAsync(key);
        // }

        [HttpGet("{key}")]
        public async Task<ActionResult<string>> Get(string key)
        {
            return await _redisDatabase.GetBranchAsync(key);
        }

        // POST api/branch
        [HttpPost]
        public async Task Post([FromBody] AddBranchViewModel viewModel)
        {
            await _redisDatabase.SetBranchAsync(viewModel.Key, viewModel.Value);
        }
    }

    public class AddBranchViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
