using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        List<Emp> emps = new List<Emp>
        {
            new Emp
            {
                Name =  "div",
                Id=1
            },

            new Emp
            {
                Name =  "pa",
                Id=2
            },

        };
        [HttpGet]
        [Route("Id")]
        public IActionResult GetEmployeeId(int Id)
        {
            try
            {

                var p = emps.Find(x => x.Id == Id);

                if (p == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(p);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           return Ok("ddd");
        }
    }
}
