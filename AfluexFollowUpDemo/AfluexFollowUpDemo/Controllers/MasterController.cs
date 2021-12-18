using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AfluexFollowUpDemo.Filter;
using System.Web.Mvc;
using AfluexFollowUpDemo.Models;
using System.Data;

namespace AfluexFollowUpDemo.Controllers
{
    public class MasterController : BaseController
    {
        //public ActionResult CategoryMaster()
        //{
        //    return View();
        //}

        [HttpPost]
        [ActionName("CategoryMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult CategoryMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["UserID"].ToString();
                DataSet ds = model.InsertCategory();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Error"] = "Category is Successfully Added";
                    }
                    else
                    {
                        TempData["Error"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("CategoryMaster", "Master");
        }
        public ActionResult InterActionMaster()
        {
            return View();
        }
        public ActionResult DataSourceMaster()
        {
            return View();
        }
        public ActionResult ProspectActivityMaster()
        {
            return View();
        }
        public ActionResult BusinessChanceMaster()
        {
            return View();
        }
        public ActionResult ProductCategoryMaster()
        {
            return View();
        }
        public ActionResult SendEmail()
        {
            return View();
        }
        public ActionResult AddEmailTemplate()
        {
            return View();
        }
        public ActionResult CategoryMaster(string Pk_CategoryId)
        {
            Master model = new Master();

            if (Pk_CategoryId != null)
            {
                Master obj = new Master();
                try
                {
                    obj.Pk_CategoryId = Pk_CategoryId;
                    DataSet ds = obj.ListCategory();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_CategoryId = ds.Tables[0].Rows[0]["Pk_CategoryId"].ToString();
                        obj.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    TempData["Master"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult CategoryList(string Pk_ProductCategoryId)
        {
            Master model = new Master();
            List<Master> lst1 = new List<Master>();
            DataSet ds = model.ListCategory();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_CategoryId = r["Pk_CategoryId"].ToString();
                    obj.CategoryName = r["CategoryName"].ToString();

                    lst1.Add(obj);
                }
                model.lstCategory = lst1;
            }
            return View(model);
        }
        [HttpPost]
        [ActionName("CategoryMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateCategoryList(string Pk_CategoryId, string CategoryName)
        {
            string FormName = "";
            string Controller = "";
            Master obj = new Master();
            try
            {
                obj.Pk_CategoryId = Pk_CategoryId;
                obj.CategoryName = CategoryName.Trim();
                obj.UpdatedBy = Session["UserID"].ToString();
                DataSet ds = obj.UpdateCategory();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        FormName = "CategoryList";
                        Controller = "Master";

                        TempData["Delete"] = "Category is Successfully Updated!";
                    }
                    else
                    {
                        Session["Pk_CategoryId"] = Pk_CategoryId;
                        FormName = "CategoryMaster";
                        Controller = "Master";
                        TempData["Error"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction(FormName, Controller);

        }

        public ActionResult InterActionList()
        {
            return View();

        }
        public ActionResult DataSourceList()
        {
            return View();
        }
        public ActionResult ProspectActivityList()

        {
            return View();
        }
        public ActionResult ProductCategoryList()
        {
            return View();
        }
        public ActionResult BusinessChanceList()
        {
            return View();
        }
        

    }
}