using Interface.Fetch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Simple.Controllers.Fetch
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FetchController : ControllerBase
    {
        private readonly IFetchService _service;

        public FetchController(IFetchService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task FetchStart(string address, int start, int limit)
        {
            await _service.ExcuteFetch(address, start, limit);
        }
    }
}