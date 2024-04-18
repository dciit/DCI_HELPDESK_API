using DCI_HELPDESK_API.Contexts;
using DCI_HELPDESK_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DCI_HELPDESK_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {
        private readonly DBSCM efSCM;

        public MainController(DBSCM efSCM)
        {
            this.efSCM = efSCM;
        }

        [HttpPost]
        [Route("/getDict")]
        public IActionResult getDict([FromBody] HelpdeskDict param)
        {
            List<HelpdeskDict> list = efSCM.HelpdeskDicts.Where(x => x.HdCategory == "WK").ToList();
            return Ok(list);
        }
    }
}
