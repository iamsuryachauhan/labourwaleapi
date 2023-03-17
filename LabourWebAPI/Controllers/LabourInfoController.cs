using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepoLayer;
using System.Data;

namespace LabourWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabourInfoController : ControllerBase
    {
        [HttpPost]
        public JsonResult fPostLabourData(M_LabourInfo m_LabourInfo)
        {
            try
            {
                var addLabr = new AddingLabourInfo();
                addLabr.addingInfo(m_LabourInfo);
                return new JsonResult("Accepted");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult fGetLabourData()
        {
            try
            {
                DataTable dtGetData = new DataTable();
                var getLabr = new AddingLabourInfo();
                dtGetData = getLabr.fGetLabourInfo();
                return new JsonResult(dtGetData);
            }
            catch (Exception ex)
            {
                var excpt = ex.Message;
                throw;
            }
        }

    }
}
