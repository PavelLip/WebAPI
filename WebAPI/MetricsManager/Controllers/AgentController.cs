using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private List<int> _ListMetrics;
        private AgentController(List<int> ListMetrics)
        {
            _ListMetrics = ListMetrics;
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentFromId([FromRoute] int agentId)
        {
            for (int i = 0; i < _ListMetrics.Count; i++)
            {
                if (_ListMetrics[i] == agentId)
                {
                    return Ok();
                }
            }
            _ListMetrics.Add(agentId);
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentFromId([FromRoute] int agentId)
        {
            for (int i = 0; i < _ListMetrics.Count; i++)
            {
                if (_ListMetrics[i] == agentId)
                {
                    _ListMetrics.Remove(i);
                    return Ok();
                }
            }
            return Ok();
        }
    }


}
