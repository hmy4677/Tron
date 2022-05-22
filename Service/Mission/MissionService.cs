using Furion.DependencyInjection;
using Furion.FriendlyException;
using Interface.Mission;
using Mapster;
using Model.Dto.Mission;
using Model.Entity;
using SqlSugar;
using SqlSugar.IOC;
using Yitter.IdGenerator;

namespace Service.Misson
{
    public class MissionService : IMissionService, ITransient
    {
        private readonly SqlSugarProvider _db;

        public MissionService()
        {
            _db = DbScoped.SugarScope.GetConnection("db1");
        }

        public async Task<dynamic> GetMissionAsync()
        {
            return await _db.Queryable<CollectTaskEntity>().ToListAsync();
        }

        public async Task<dynamic> RunStopMission(long id)
        {
            var mission = await _db.Queryable<CollectTaskEntity>().FirstAsync(p => p.Id == id);
            mission.Status = mission.Status == 1 ? 0 : 1;
            var count = await _db.Updateable(mission).IgnoreColumns(true).ExecuteCommandAsync();
            return new { count };
        }

        public async Task<dynamic> AddMission(MissionAddUpdateInput input)
        {
            var newmission = input.Adapt<CollectTaskEntity>();
            newmission.Id = YitIdHelper.NextId();
            newmission.Status = 0;
            newmission.LastCollectTime = null;
            var count = await _db.Insertable(newmission).ExecuteCommandAsync();
            return new { count };
        }

        public async Task<dynamic> UpdateMission(long id, MissionAddUpdateInput input)
        {
            var mission = await _db.Queryable<CollectTaskEntity>().FirstAsync(p => p.Id == id);
            _ = mission ?? throw Oops.Oh("data isn't exist");
            mission = input.Adapt(mission);
            var count = await _db.Updateable(mission).ExecuteCommandAsync();
            return new { count };
        }

        public async Task<dynamic> DeleteMission(long id)
        {
            var mission = await _db.Queryable<CollectTaskEntity>().FirstAsync(p => p.Id == id);
            _ = mission ?? throw Oops.Oh("data isn't exist");
            var count = await _db.Deleteable(mission).ExecuteCommandAsync();
            return new { count };
        }
    }
}