using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
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


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Emp))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
                    return Ok("");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("ddd");
        }



        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Emp employee)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                // Create a dictionary to hold the details of each validation error
                var errors = ModelState
                    .Where(e => e.Value?.Errors.Count > 0) // Filter model state entries that have errors
                    .ToDictionary(
                        kvp => kvp.Key, // Use the property name as the key
                        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() // Use the error messages as the value
                    );
                // Create a ProblemDetails object to hold the error response details
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Title = "Validation Errors Occurred.", // Short description of the problem
                    Detail = "See the errors property for details", // Detailed description of the problem
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1", // URI reference for the problem type
                    Status = StatusCodes.Status400BadRequest, // HTTP status code for the response
                    Instance = HttpContext.Request.Path, // The path to the request that generated the error
                };
                // Return a 400 Bad Request response with the problem details
                return BadRequest(problemDetails);
            }
            // Process the request (e.g., save the employee data to the database)
            // ...
            // Return a 200 OK response indicating success
            return Ok();
        }

    }
}
