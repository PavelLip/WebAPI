using System;
using Xunit;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;

//namespace MetricsManager_Test
//{
//    public class AgentControllerUnitTest
//    {
//        private AgentController controller;

//        public AgentControllerUnitTest()
//        {
//            controller = new AgentController(); 
//        }

//        [Fact]
//        public void RegisterAgent_ReturnsOk()
//        {
//            var agent = new AgentInfo();
//            agent.AgentId = 1;

//            var result = controller.RegisterAgent(agent);

//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }

//        [Fact]
//        public void EnableAgentFromId_ReturnsOk()
//        {
//            var agentId = 1;

//            var result = controller.EnableAgentFromId(agentId);

//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }

//        [Fact]
//        public void DisableAgentFromId_ReturnsOk()
//        {
//            var agentId = 1;

//            var result = controller.DisableAgentFromId(agentId);

//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }
//    }
//}
