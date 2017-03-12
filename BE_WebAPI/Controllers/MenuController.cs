using BE.Data;
using BE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BE_WebAPI.Controllers
{
    public class MenuController : ApiController
    {
        public IHttpActionResult Get(string id)
        {
            using (MenuOperations _menuOperation = new MenuOperations())
            {
                IEnumerable<MenuItem> lstMenu = _menuOperation.GetMenuByDesignation(Convert.ToInt32(id));
                if (lstMenu == null)
                    return NotFound();
                else
                    return Ok(lstMenu);
            }
        }
    }
}
