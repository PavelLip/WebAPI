//using System;
//using Xunit;
//using Microsoft.AspNetCore.Mvc;


//namespace MetricsManager.Test
//{
//    public class AgentControllerTest
//    {

//        private Controllers.CpuMetricsController controller;

//        public AgentControllerTest()
//        {
//            controller = new Controllers.CpuMetricsController();
//        }


//        [Fact]
//        public void AgentController_ReturnOk()
//        {
//            //Arrange
//            var agentId = 1;
//            var fromTime = TimeSpan.FromSeconds(0);
//            var toTime = TimeSpan.FromSeconds(100);

//            //Act
//            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);

//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }










//        //[Fact]
//        //public void Chek_ReturnOk()
//        //{
            



//        //    //����������
//        //    var controller = new Controllers.AgentController();
//        //    //���������
//        //    var result = controller.RegisterAgent();
//        //    //�������� ����������
//        //    Assert.IsAssignableFrom<IActionResult>(result);
//        //}
//    }
//}
