using Hangfire;
using Microsoft.AspNetCore.Mvc;
using OurAppWithHangfire.Interface;
using OurAppWithHangfire.Repository;
using OurAppWithHangfire.Services;

namespace OurAppWithHangfire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> _logger;
        private readonly IBackGroundJobService _customJobService;

        public JobsController(ILogger<JobsController> logger, IBackGroundJobService customJobService)
        {
            _logger = logger;
            _customJobService = customJobService;
        }

        [HttpPost]
        public async Task RunJob()
        {
            await Task.Run(() => null);
            
            //await Task.Run(() => RecurringJob.AddOrUpdate<IBackGroundJobService>("Database Script Backup", _customJobService => _customJobService.RunJob(), Cron.Minutely));
            //await Task.Run(() => RecurringJob.AddOrUpdate<IBackGroundJobService>("Database Script Backup", service => service.RunJob(), "32 17 * * *"));
        }
    }
}
