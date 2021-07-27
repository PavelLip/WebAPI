using System;
using Xunit;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager_Test
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController controller;

        public HddMetricsControllerUnitTest()
        {
            controller = new HddMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromClaster_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsFromAllClasters(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
