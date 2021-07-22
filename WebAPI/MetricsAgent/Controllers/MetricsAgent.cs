using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsAgent : ControllerBase
    {
        /*
    * Метод позволяющий получить список зарегистрированных в системе объектов.
    * добавить контроллеры для сбора метрик аналогичные менеджеру сбора метрик. 

    * Добавить методы для получения метрик с агента, доступные по следующим путям
       api/metrics/cpu/from/{fromTime}/to/{toTime}
       api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
       api/metrics/network/from/{fromTime}/to/{toTime}
       api/metrics/hdd/left/from/{fromTime}/to/{toTime}
       api/metrics/ram/available/from/{fromTime}/to/{toTime}

    */



    }
}
