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
    public class HddMetricsController : ControllerBase
    {
        private IHddMetricsRepository repository;

        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsController(IHddMetricsRepository repository, ILogger<HddMetricsController> logger)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsHdd([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(HddMetricsController - GetMetricsHdd)");
            var metrics = repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(HddMetricsController - Create)");
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
            _logger.LogInformation("Привет! Это наше первое сообщение в лог(HddMetricsController - GetAll)");
            var metrics = repository.GetAll();

            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }
    }
}
