using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent_Test
{
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController controller;

        public DotNetMetricsControllerUnitTest()
        {
            controller = new DotNetMetricsController();
        }

        [Fact]
        public void GetMetricsDotNet_ReturnsOk()
        {
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsDotNet(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
