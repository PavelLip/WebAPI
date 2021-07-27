using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/agent")]
    [ApiController]
    public class MetricsAgent : ControllerBase
    {
        Process[] RegOObjects { get; }
        MetricsAgent()
        {
            RegOObjects = RegisteredObjectsSystem();
        }

        [HttpGet]
        Process[] RegisteredObjectsSystem()
        {
            Process[] objectsSystem = Process.GetProcesses();
            return objectsSystem;
        }
    }
}
