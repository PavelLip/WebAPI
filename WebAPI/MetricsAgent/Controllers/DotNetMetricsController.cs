using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using MetricsAgent.DAL;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;

        private IDotNetMetricsRepository repository;

        public DotNetMetricsController(IDotNetMetricsRepository repository, ILogger<DotNetMetricsController> logger)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }

    [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsDotNet([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(DotNetMetricsController - GetMetricsDotNet)");
            var metrics = repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new DotNetMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(DotNetMetricsController - Create)");
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
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(GetMetricsDotNet - GetAll)");
            var metrics = repository.GetAll();

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new DotNetMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }
    }
}
