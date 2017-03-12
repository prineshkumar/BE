using BE.Data;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace BE_WebAPI.Controllersid
{
    [RoutePrefix("api/branch")]
    public class BranchOpsController : ApiController
    {
        [HttpGet]
        [Route("getbranch/{id}")]
        public IHttpActionResult GetBranchDetails(string id)
        {
            IEnumerable<Branch> _lstBranchDetails = null;
            using (BranchOperations _branchOperation = new BranchOperations())
            {
                _lstBranchDetails = _branchOperation.GetBranchDetailsByEmployee(Convert.ToInt32(id));
            }
            return Ok(_lstBranchDetails);
        }

        [Route("addbranch")]
        [HttpPost]
        public IHttpActionResult AddNewBranch()
        {
            return Ok("");
        }

        [Route("updatebranch")]
        [HttpPut]
        public IHttpActionResult UpdateBranch()
        {
            return Ok("");
        }

        [Route("addroom")]
        [HttpPut]
        public IHttpActionResult AddNewRoom()
        {
            return Ok("");
        }

        [Route("updateroom")]
        [HttpPut]
        public IHttpActionResult UpdateRoom()
        {
            return Ok("");
        }

        [HttpOptions]
        public void Options()
        {

        }
    }
}