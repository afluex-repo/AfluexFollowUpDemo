using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluexFollowUpDemo.Controllers
{
    public class EmployeeLeadController : Controller
    {
        // GET: EmployeeLead
        public ActionResult AddLead()
        {
            return View();
        }
        public ActionResult ListLead()
        {
            return View();
        }
    }
}