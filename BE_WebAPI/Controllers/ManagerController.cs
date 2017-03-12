using BE.Data;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BE_WebAPI.Controllers
{
    [RoutePrefix("api/manager")]
    public class ManagerController : ApiController
    {
        [HttpGet]
        [Route("GetComplaints/{id}")]
        public IHttpActionResult GetComplaints(string id)
        {
            using (UserOperations _userOperation = new UserOperations())
            {
                IEnumerable<Complaint> _complaintDetails = _userOperation.GetComplaintDetailsByEmployee(Convert.ToInt32(id));
                if (_complaintDetails == null || _complaintDetails.Count() == 0)
                    return NotFound();
                else
                    return Ok(_complaintDetails);
            }
        }
    }
}