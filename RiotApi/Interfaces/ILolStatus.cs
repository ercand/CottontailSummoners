using RiotApi.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApi.Interfaces
{
    public interface ILolStatus
    {
        List<RiotApi.Dto.LolStatus.ShardDto> GetShards();
        Task<List<RiotApi.Dto.LolStatus.ShardDto>> GetShardsAsync();

        RiotApi.Dto.LolStatus.ShardStatusDto GetShardByRegion(Enums.Region region);
        Task<RiotApi.Dto.LolStatus.ShardStatusDto> GetShardByRegionAsync(Enums.Region region);
    }
}
