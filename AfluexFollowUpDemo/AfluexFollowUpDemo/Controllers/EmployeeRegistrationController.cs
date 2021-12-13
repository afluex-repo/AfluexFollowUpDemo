using AfluexFollowUpDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AluexFollowUpDemo.Controllers
{
    public class EmployeeRegistrationController : Controller
    {
        // GET: EmployeeRegistration
        public ActionResult EmployeeRegistration()
        {
            Session.Abandon();
            return View();
        }
        public ActionResult GetEmpolyeeRegistrationList()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            Lead obj = new Lead();
            List<Lead> lst1 = new List<Lead>();
            List<Lead> lstnext = new List<Lead>();
            List<Lead> lstpending = new List<Lead>();
            obj.FromDate = DateTime.Now.ToString("MM/dd/yyyy");
            obj.ToDate = DateTime.Now.ToString("MM/dd/yyyy");
            obj.EmployeeId = Session["ExecutiveID"].ToString();
            DataSet ds = obj.GetDashBoardDetails();
            if (ds != null && ds.Tables.Count > 0)
            {
                #region TodayFollowup
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {

                        Lead obj1 = new Lead();

                        obj1.Fk_ProcpectId = r["ContactPerson"].ToString();
                        obj1.FirstInstructionDate = r["FirstInstructionDate"].ToString();
                        obj1.Fk_ExpectedProductCategoryId = r["ProductCategoryName"].ToString();
                        obj1.Fk_SourceId = r["SourceName"].ToString();
                        obj1.Fk_ExecutiveId = r["Name"].ToString();
                        obj1.Fk_ModeInterActionId = r["InterActionName"].ToString();
                        obj1.FollowupDate = r["FollowupDate"].ToString();
                        obj1.Description = r["Description"].ToString();

                        lst1.Add(obj1);
                    }
                    #endregion TodayFollowup
                    obj.lstLead = lst1;
                }

                #region NextFollowup
                if (ds.Tables[1].Rows.Count > 0)
                {


                    foreach (DataRow r in ds.Tables[1].Rows)

                    {

                        Lead obj1 = new Lead();

                        obj1.Fk_ProcpectId = r["ContactPerson"].ToString();
                        obj1.FirstInstructionDate = r["FirstInstructionDate"].ToString();
                        obj1.Fk_ExpectedProductCategoryId = r["ProductCategoryName"].ToString();
                        obj1.Fk_SourceId = r["SourceName"].ToString();
                        obj1.Fk_ExecutiveId = r["Name"].ToString();
                        obj1.Fk_ModeInterActionId = r["InterActionName"].ToString();
                        obj1.FollowupDate = r["FollowupDate"].ToString();
                        obj1.Description = r["Description"].ToString();

                        lstnext.Add(obj1);
                    }
                    #endregion NextFollowup
                    obj.lstnextLead = lstnext;
                }

                #region PendingFollowup
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[2].Rows)
                    {

                        Lead obj1 = new Lead();
                        obj1.Fk_ProcpectId = r["ContactPerson"].ToString();
                        obj1.Fk_ProcpectId = r["ContactPerson"].ToString();
                        obj1.FirstInstructionDate = r["FirstInstructionDate"].ToString();
                        obj1.Fk_ExpectedProductCategoryId = r["ProductCategoryName"].ToString();
                        obj1.Fk_SourceId = r["SourceName"].ToString();
                        obj1.Fk_ExecutiveId = r["Name"].ToString();
                        obj1.Fk_ModeInterActionId = r["InterActionName"].ToString();
                        obj1.FollowupDate = r["FollowupDate"].ToString();
                        obj1.Description = r["Description"].ToString();

                        lstpending.Add(obj1);
                    }
                    obj.lstpending = lstpending;
                }
                #endregion PendingFollowup
            }
            return View(obj);
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}