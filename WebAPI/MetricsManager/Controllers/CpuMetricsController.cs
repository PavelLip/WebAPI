using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        public List<AgentInfo> ListCpuMetrics;

        //[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        [HttpGet("agent")]
        public IActionResult GetMetricsFromAgent()
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllClasters([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var x = DateTime.Now.TimeOfDay;
            while (x < fromTime && x <= toTime)
            {
                if (x >= fromTime)
                {
                    var y = Process.GetProcesses();

                    for (int i = 0; i < y.Length; i++)
                    {
                        ListCpuMetrics.Add(new AgentInfo { AgentId = y[i].Id });
                    }
                }
            }
            return Ok(ListCpuMetrics);
        }
    }
}
