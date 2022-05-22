using Model.Dto.Mission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Mission
{
    public interface IMissionService
    {
        Task<dynamic> GetMissionAsync();

        Task<dynamic> RunStopMission(long id);

        Task<dynamic> AddMission(MissionAddUpdateInput input);

        Task<dynamic> UpdateMission(long id, MissionAddUpdateInput input);

        Task<dynamic> DeleteMission(long id);
    }
}
