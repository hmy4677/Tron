using Furion.DynamicApiController;
using Interface.Mission;
using Microsoft.AspNetCore.Mvc;
using Model.Dto.Mission;

namespace Simple.Controllers.Mission
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _service;

        public MissionController(IMissionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<dynamic> GetMissionListAsync()
        {
            var list = await _service.GetMissionAsync();
            return list;
        }

        [HttpPatch("{id}")]
        public async Task<dynamic> RunOrStop(long id)
        {
            var data = await _service.RunStopMission(id);
            return data;
        }

        [HttpDelete("{id}")]
        public async Task<dynamic> Del(long id)
        {
            var data = await _service.DeleteMission(id);
            return data;
        }

        [HttpPost]
        public async Task<dynamic> Add([FromBody] MissionAddUpdateInput input)
        {
            var data = await _service.AddMission(input);
            return data;
        }

        [HttpPut("{id}")]
        public async Task<dynamic> Update(long id, [FromBody] MissionAddUpdateInput input)
        {
            var data = await _service.UpdateMission(id, input);
            return data;
        }
    }
}