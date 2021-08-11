using System;
using Xunit;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;

//namespace MetricsManager_Test
//{
//    public class CpuMetricsControllerUnitTest
//    {
//        private CpuMetricsController controller;

//        public CpuMetricsControllerUnitTest()
//        {
//            controller = new CpuMetricsController();
//        }

//        [Fact]
//        public void GetMetricsFromAgent_ReturnsOk()
//        {
//            var agentId = 1;
//            var fromTime = TimeSpan.FromSeconds(0);
//            var toTime = TimeSpan.FromSeconds(100);

//            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);

//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }

//        [Fact]
//        public void GetMetricsFromClaster_ReturnsOk()
//        {
//            var fromTime = TimeSpan.FromSeconds(0);
//            var toTime = TimeSpan.FromSeconds(100);

//            var result = controller.GetMetricsFromAllCluster(fromTime, toTime);

//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }
//    }
//}
