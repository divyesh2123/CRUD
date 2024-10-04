using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            var p = new JobPortalJobsContext();

            return Ok(p.JobPortals.ToList());
        }
    }
}
