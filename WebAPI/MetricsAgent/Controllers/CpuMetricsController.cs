using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MetricsAgent.DAL;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.Extensions.Logging;


namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private ICpuMetricsRepository repository;

        private readonly ILogger<CpuMetricsController> _logger;

        public CpuMetricsController(ICpuMetricsRepository repository, ILogger<CpuMetricsController> logger)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsCpu([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(CpuMetricsController - GetMetricsCpu)");
            var metrics = repository.GetByTimePeriod(fromTime, toTime); 

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(CpuMetricsController - Create)");
            repository.Create(new MetricData
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(CpuMetricsController - GetAll)");
            var metrics = repository.GetAll();

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }
    }
}