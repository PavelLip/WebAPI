using MetricsAgent.Controllers;
using MetricsAgent.DAL;
//using MetricsAgent.Models;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MetricsAgent_Test
{
    public class CpuMetricsControllerUnitTests
    {

        //ничего не понимаю с тестами

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

        [Fact]
        public void Create_ShouldCall_GetAll_Repository()
        {
            mock.Setup(repository => repository.GetAll()).Verifiable();

            var result = controller.GetAll();

            mock.Verify(repository => repository.GetAll());
        }
    }
}
