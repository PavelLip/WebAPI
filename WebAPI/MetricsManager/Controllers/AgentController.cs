using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly ILogger<AgentController> _logger;

        public AgentController(ILogger<AgentController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в AgentController");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(RegisterAgent)");
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentFromId([FromRoute] int agentId)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(EnableAgentFromId)");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentFromId([FromRoute] int agentId)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(DisableAgentFromId)");
            return Ok();
        }
    }
}
