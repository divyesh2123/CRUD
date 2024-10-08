using JobPortal.Commuincation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JobPortal.Commuincation.Model;
using d = JobPortal.Commuincation.Model.JobPortal;

namespace JobPortal.Commuincation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            Common common = new Common();   

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7086/");
               
                //GET Method
                HttpResponseMessage response = await client.GetAsync("/api/user");
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadAsStringAsync();

                    var p =JsonConvert.DeserializeObject<List<UserInfo>>(user);

                    common.userInfo = p;
                }
               
            }


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7283/");

                //GET Method
                HttpResponseMessage response = await client.GetAsync("/api/jobs");
                if (response.IsSuccessStatusCode)
                {
                    var jobs = await response.Content.ReadAsStringAsync();

                    var p1 = JsonConvert.DeserializeObject<List<d>>(jobs);

                    common.jobPortal = p1;
                }

            }

            return Ok(common);

        }
    }
}
