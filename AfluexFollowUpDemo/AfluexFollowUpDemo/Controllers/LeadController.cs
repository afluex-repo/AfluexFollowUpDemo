using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfluexFollowUpDemo.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
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