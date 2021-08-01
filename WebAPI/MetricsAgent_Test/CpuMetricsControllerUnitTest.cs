//using System;
//using Xunit;
//using MetricsAgent.Controllers;
//using Microsoft.AspNetCore.Mvc;

using MetricsAgent.Controllers;
using MetricsAgent.DAL;
//using MetricsAgent.Models;
using Moq;
using System;
using Xunit;

namespace MetricsAgent_Test
{
    //public class CpuMetricsControllerUnitTest
    //{
    //    private CpuMetricsController controller;

    //    public CpuMetricsControllerUnitTest()
    //    {
    //        controller = new CpuMetricsController();
    //    }

    //    [Fact]
    //    public void GetMetricsCpu_ReturnsOk()
    //    {
    //        var agentId = 1;
    //        var fromTime = TimeSpan.FromSeconds(0);
    //        var toTime = TimeSpan.FromSeconds(100);

    //        var result = controller.GetMetricsCpu(agentId, fromTime, toTime);

    //        _ = Assert.IsAssignableFrom<IActionResult>(result);
    //    }
    //}




    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> mock;

        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricsRepository>();

            controller = new CpuMetricsController(mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<MetricData>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<MetricData>()), Times.AtMostOnce());
        }
    }
}
