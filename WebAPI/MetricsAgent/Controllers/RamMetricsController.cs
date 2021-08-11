using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using MetricsAgent.DAL;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private IRamMetricsRepository repository;

        private readonly ILogger<RamMetricsController> _logger;

        public RamMetricsController(IRamMetricsRepository repository, ILogger<RamMetricsController> logger)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в RamMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsRam([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(NetworkMetricsController - GetMetricsRam)");
            var metrics = repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(NetworkMetricsController - Create)");
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
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(NetworkMetricsController - GetAll)");
            var metrics = repository.GetAll();

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }
    }
}
