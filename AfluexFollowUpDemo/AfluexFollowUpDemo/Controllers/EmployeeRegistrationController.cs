using AfluexFollowUpDemo.Filter;
using AfluexFollowUpDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfluexFollowUpDemo.Controllers
{
    public class EmployeeRegistrationController : BaseController
    {
        // GET: EmployeeRegistration
        public ActionResult EmployeeRegistration(string Pk_Id)
        {
            EmployeeRegistration model = new EmployeeRegistration();
            #region BindUsertype
            int count = 0;
            List<SelectListItem> ddlUserName = new List<SelectListItem>();
            DataSet ds = model.BindUserType();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (count == 0)
                    {
                        ddlUserName.Add(new SelectListItem { Text = "Select User Type", Value = "0" });
                    }
                    ddlUserName.Add(new SelectListItem { Text = r["UserName"].ToString(), Value = r["Pk_UserTypeID"].ToString() });
                    count = count + 1;
                }
            }

            ViewBag.ddlUserName = ddlUserName;
            #endregion
            if (Pk_Id != null)
            {
                EmployeeRegistration obj = new EmployeeRegistration();
                try
                {
                    obj.Pk_Id = Pk_Id;
                    DataSet ds1 = obj.GetEmployeeList();
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_Id = ds1.Tables[0].Rows[0]["Pk_Id"].ToString();
                        obj.Fk_UserTypeId = ds1.Tables[0].Rows[0]["Fk_UserTypeId"].ToString();
                        obj.Name = ds1.Tables[0].Rows[0]["Name"].ToString();
                        obj.ContactNo = ds1.Tables[0].Rows[0]["ContactNo"].ToString();
                        obj.EmailId = ds1.Tables[0].Rows[0]["EmailId"].ToString();
                        obj.Address = ds1.Tables[0].Rows[0]["Address"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    TempData["ServiceError"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult GetEmpolyeeRegistrationList()
        {
            return View();
        }
     

        [HttpPost]
        [ActionName("GetEmpolyeeRegistrationList")]
        [OnAction(ButtonName = "GetDetails")]
        public ActionResult FilterEmployee(EmployeeRegistration model)
        {
            List<EmployeeRegistration> lst = new List<EmployeeRegistration>();
            try
            {
                model.Pk_Id = Session["UserID"].ToString();
                DataSet ds = model.FilterEmployee();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables.Count > 0)
                {

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {

                        EmployeeRegistration obj = new EmployeeRegistration();
                        obj.Pk_Id = r["Pk_Id"].ToString();
                        obj.Fk_UserTypeId = r["UserName"].ToString();
                        obj.Name = r["Name"].ToString();
                        obj.ContactNo = r["ContactNo"].ToString();
                        obj.EmailId = r["EmailId"].ToString();
                        obj.Address = r["Address"].ToString();
                        obj.UserImage = string.IsNullOrEmpty(r["UserImage"].ToString()) ? " ../SoftwareImages/d2.jpg" : r["UserImage"].ToString();
                        lst.Add(obj);
                    }
                    model.lstemployee = lst;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
