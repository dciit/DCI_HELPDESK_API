using DCI_HELPDESK_API.Contexts;
using DCI_HELPDESK_API.Interface;
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
        [Route("/getDictByCategory")]
        public IActionResult getDict([FromBody] MGetDict param)
        {
            string dictCategory = param.dictCategory;
            List<HelpdeskDict> list = new List<HelpdeskDict>();
            if (dictCategory != "")
            {
                list = efSCM.HelpdeskDicts.Where(x => x.DictCategory == dictCategory).ToList();
            }
            return Ok(list);
        }

        [HttpPost]
        [Route("/insertJob")]
        public IActionResult insertJob([FromBody] MInsertJob param)
        {
            string hdCode = param.hdCode;
            string JobReqBy = param.jobReqBy;
            int? JobFac = param.jobFac;
            string JobLocation = param.jobLocation;
            HelpdeskJob newRow = new HelpdeskJob();
            newRow.HdCode = hdCode;
            newRow.JobFac = JobFac;
            newRow.JobLocation = JobLocation;
            newRow.JobReqBy = JobReqBy;
            newRow.UpdateBy = JobReqBy;
            newRow.JobReqDate = DateTime.Now;
            efSCM.HelpdeskJobs.Add(newRow);
            int insert = efSCM.SaveChanges();
            return Ok(new
            {
                status = insert
            });
        }

        [HttpPost]
        [Route("/acceptJob")]
        public IActionResult receivedJob([FromBody] MReceivedJob param)
        {
            int jobId = param.jobId;
            string jobReceivedBy = param.jobReveivedBy;
            HelpdeskJob jobCurrent = efSCM.HelpdeskJobs.Where(x => x.JobId == jobId).FirstOrDefault();
            if (jobCurrent != null)
            {
                jobCurrent.JobAcceptBy = jobReceivedBy;
                jobCurrent.JobAcceptDate = DateTime.Now;
                jobCurrent.UpdateDate = DateTime.Now;
                jobCurrent.UpdateBy = jobReceivedBy;
                efSCM.HelpdeskJobs.Update(jobCurrent);
            }
            int update = efSCM.SaveChanges();
            return Ok(new
            {
                status = update
            });
        }

        [HttpPost]
        [Route("/finishJob")]
        public IActionResult finishJob([FromBody] MFinalJob param)
        {
            int jobId = param.jobId;
            string jobFinishBy = param.jobFinishBy;
            HelpdeskJob jobCurrent = efSCM.HelpdeskJobs.Where(x => x.JobId == jobId).FirstOrDefault();
            if (jobCurrent != null)
            {
                jobCurrent.JobFinishDate = DateTime.Now;
                jobCurrent.UpdateDate = DateTime.Now;
                jobCurrent.UpdateBy = jobFinishBy;
                efSCM.HelpdeskJobs.Update(jobCurrent);
            }
            int update = efSCM.SaveChanges();
            return Ok(new
            {
                status = update
            });
        }
    }
}
