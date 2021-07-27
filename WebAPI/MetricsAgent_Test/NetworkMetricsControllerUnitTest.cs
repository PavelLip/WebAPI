using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace MetricsAgent_Test
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController controller;

        public NetworkMetricsControllerUnitTest()
        {
            controller = new NetworkMetricsController();
        }

        [Fact]
        public void GetMetricsNetwork_ReturnsOk()
        {
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetricsNetwork(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
