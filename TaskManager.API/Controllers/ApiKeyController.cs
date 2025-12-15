using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.DAL.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeyController : ControllerBase
    {
        private readonly ApiKeyFakeService _service;

        public ApiKeyController(ApiKeyFakeService service)
        {
            _service = service;
        }

        [HttpGet("{apiKey:key}")]
        public string CheckApiKeyByRoute([FromRoute] string apiKey)
        {
            return "Clé valide";
        }

        [HttpGet]
        public string CheckApiKeyByQuery([FromQuery] string apiKey)
        {
            return _service.IsValid(apiKey)? "Clé valide" : throw new InvalidOperationException();
        }
    }
}
