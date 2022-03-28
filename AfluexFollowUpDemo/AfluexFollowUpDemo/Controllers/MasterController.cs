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
        public ActionResult InterActionMaster(string PK_InterActionId)
        {
            Master model = new Master();
            if (PK_InterActionId != null)
            {
                Master obj = new Master();
                try
                {
                    obj.PK_InterActionId = PK_InterActionId;
                    DataSet ds = obj.ListInterAction();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.PK_InterActionId = ds.Tables[0].Rows[0]["PK_InterActionId"].ToString();
                        obj.InterActionName = ds.Tables[0].Rows[0]["InterActionName"].ToString();

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
        [HttpPost]
        [ActionName("InterActionMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult InterAction(Master model)
        {
            try
            {
                model.AddedBy = Session["UserID"].ToString();
                DataSet ds = model.InsertInterAction();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Error"] = "InterAction is Successfully Added";
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
            return RedirectToAction("InterActionMaster");
        }
        [HttpPost]
        [ActionName("InterActionMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateInterActionList(string PK_InterActionId, string InterActionName)
        {
            string FormName = "";
            string Controller = "";
            Master obj = new Master();
            try
            {
                obj.PK_InterActionId = PK_InterActionId;
                obj.InterActionName = InterActionName.Trim();
                obj.UpdatedBy = Session["UserID"].ToString();
                DataSet ds = obj.UpdateInterAction();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        FormName = "InterActionList";
                        Controller = "Master";

                        TempData["Delete"] = "InterAction is Successfully Updated!";
                    }
                    else
                    {
                        //Session["PK_InterActionId"] = PK_InterActionId;
                        FormName = "InterActionMaster";
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

        public ActionResult DataSourceMaster(string Pk_SourceId)
        {
            Master model = new Master();
            if (Pk_SourceId != null)
            {
                Master obj = new Master();
                try
                {
                    obj.Pk_SourceId = Pk_SourceId;
                    DataSet ds = obj.ListDataSource();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_SourceId = ds.Tables[0].Rows[0]["Pk_SourceId"].ToString();
                        obj.SourceName = ds.Tables[0].Rows[0]["SourceName"].ToString();
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
        [HttpPost]
        [ActionName("DataSourceMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult DataSourceMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["UserID"].ToString();
                DataSet ds = model.InsertDataSource();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Error"] = "Source Of Data is Successfully Added";
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
            return RedirectToAction("DataSourceMaster");
        }


        public ActionResult ProspectActivityMaster(string Pk_ActivityId)
        {
            Master model = new Master();

            if (Pk_ActivityId != null)
            {
                Master obj = new Master();
                try
                {
                    obj.Pk_ActivityId = Pk_ActivityId;
                    DataSet ds = obj.ListActivity();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_ActivityId = ds.Tables[0].Rows[0]["Pk_ActivityId"].ToString();
                        obj.ActivityName = ds.Tables[0].Rows[0]["ActivityName"].ToString();

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

        [HttpPost]
        [ActionName("ProspectActivityMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult ProspectActivityMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["UserID"].ToString();
                DataSet ds = model.InsertProspectActivity();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Error"] = "Prospect Activity is Successfully Added";
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
            return RedirectToAction("ProspectActivityMaster");
        }

        public ActionResult ProspectActivityList(string Pk_ActivityId)
        {
            Master model = new Master();
            List<Master> lst1 = new List<Master>();

            DataSet ds = model.ListActivity();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_ActivityId = r["Pk_ActivityId"].ToString();
                    obj.ActivityName = r["ActivityName"].ToString();

                    lst1.Add(obj);
                }
                model.lstActivity = lst1;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("ProspectActivityMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateProspectActivityList(string Pk_ActivityId, string ActivityName)
        {
            string FormName = "";
            string Controller = "";
            Master obj = new Master();
            try
            {
                obj.Pk_ActivityId = Pk_ActivityId;
                obj.ActivityName = ActivityName.Trim();
                obj.UpdatedBy = Session["UserID"].ToString();
                DataSet ds = obj.UpdateActivity();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        FormName = "ProspectActivityList";
                        Controller = "Master";

                        TempData["Delete"] = "Prospect Activity is Successfully Updated!";
                    }
                    else
                    {
                        //Session["Pk_ActivityId"] = Pk_ActivityId;
                        FormName = "ProspectActivityMaster";
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

        public ActionResult BusinessChanceMaster(string Pk_BusinessChanceId)
        {
            Master model = new Master();

            if (Pk_BusinessChanceId != null)
            {
                Master obj = new Master();
                try
                {
                    obj.Pk_BusinessChanceId = Pk_BusinessChanceId;
                    DataSet ds = obj.ListBusinessChance();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_BusinessChanceId = ds.Tables[0].Rows[0]["Pk_BusinessChanceId"].ToString();
                        obj.ChanceName = ds.Tables[0].Rows[0]["ChanceName"].ToString();

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

        [HttpPost]
        [ActionName("BusinessChanceMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult BusinessChanceMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["UserID"].ToString();
                DataSet ds = model.InsertBusinessChance();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Error"] = "Business Chance is Successfully Added";
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
            return RedirectToAction("BusinessChanceMaster");
        }

        public ActionResult BusinessChanceList(string Pk_BusinessChanceId)
        {
            Master model = new Master();
         //  model.Pk_BusinessChanceId = Pk_BusinessChanceId;
            List<Master> lst1 = new List<Master>();

            DataSet ds = model.ListBusinessChance();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_BusinessChanceId = r["Pk_BusinessChanceId"].ToString();
                    obj.ChanceName = r["ChanceName"].ToString();

                    lst1.Add(obj);
                }
                model.lstChance = lst1;
            }
            return View(model);


        }

        [HttpPost]
        [ActionName("BusinessChanceMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateBusinessChanceList(string Pk_BusinessChanceId, string ChanceName)
        {
            string FormName = "";
            string Controller = "";
            Master obj = new Master();
            try
            {
                obj.Pk_BusinessChanceId = Pk_BusinessChanceId;
                obj.ChanceName = ChanceName.Trim();
                obj.UpdatedBy = Session["UserID"].ToString();
                DataSet ds = obj.UpdateBusinessChance();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        FormName = "BusinessChanceList";
                        Controller = "Master";

                        TempData["Delete"] = "Business Chance is Successfully Updated!";
                    }
                    else
                    {
                        //Session["Pk_BusinessChanceId"] = Pk_BusinessChanceId;
                        FormName = "BusinessChanceMaster";
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
        public ActionResult InterActionList(string PK_InterActionId)
        {
            Master model = new Master();
            List<Master> lst1 = new List<Master>();

            DataSet ds = model.ListInterAction();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_InterActionId = r["PK_InterActionId"].ToString();
                    obj.InterActionName = r["InterActionName"].ToString();

                    lst1.Add(obj);
                }
                model.lstInterAction = lst1;
            }
            return View(model);

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


        public ActionResult DataSourceList(string Pk_SourceId)
        {
            Master model = new Master();
            List<Master> lst1 = new List<Master>();

            DataSet ds = model.ListDataSource();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_SourceId = r["Pk_SourceId"].ToString();
                    obj.SourceName = r["SourceName"].ToString();

                    lst1.Add(obj);
                }
                model.lstSource = lst1;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("DataSourceMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateDataSourceList(string Pk_SourceId, string SourceName)
        {
            string FormName = "";
            string Controller = "";
            Master obj = new Master();
            try
            {
                obj.Pk_SourceId = Pk_SourceId;
                obj.SourceName = SourceName.Trim();
                obj.UpdatedBy = Session["UserID"].ToString();
                DataSet ds = obj.UpdateDataSource();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        FormName = "DataSourceList";
                        Controller = "Master";

                        TempData["Delete"] = "Data Source is Successfully Updated!";
                    }
                    else
                    {
                        //Session["Pk_SourceId"] = Pk_SourceId;
                        FormName = "DataSourceMaster";
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

        public ActionResult ProductCategoryMaster(string Pk_ProductCategoryId)
        {
            Master model = new Master();

            if (Pk_ProductCategoryId != null)
            {
                Master obj = new Master();
                try
                {
                    obj.Pk_ProductCategoryId = Pk_ProductCategoryId;
                    DataSet ds = obj.ListProductCategory();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.Pk_ProductCategoryId = ds.Tables[0].Rows[0]["Pk_ProductCategoryId"].ToString();
                        obj.ProductCategoryName = ds.Tables[0].Rows[0]["ProductCategoryName"].ToString();

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
        [HttpPost]
        [ActionName("ProductCategoryMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult ProductCategoryMaster(Master model)
        {
            try
            {
                model.AddedBy = Session["UserID"].ToString();
                DataSet ds = model.ExpectedProductCategoryInsert();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Error"] = "Product Category is Successfully Added";
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
            return RedirectToAction("ProductCategoryMaster");
        }

        public ActionResult ProductCategoryList(string Pk_ProductCategoryId)
        {
            Master model = new Master();
            List<Master> lst1 = new List<Master>();

            DataSet ds = model.ListProductCategory();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.Pk_ProductCategoryId = r["Pk_ProductCategoryId"].ToString();
                    obj.ProductCategoryName = r["ProductCategoryName"].ToString();

                    lst1.Add(obj);
                }
                model.lstProductCategory = lst1;
            }
            return View(model);

        }

        [HttpPost]
        [ActionName("ProductCategoryMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateProductCategoryList(string Pk_ProductCategoryId, string ProductCategoryName)
        {
            string FormName = "";
            string Controller = "";
            Master obj = new Master();
            try
            {
                obj.Pk_ProductCategoryId = Pk_ProductCategoryId;
                obj.ProductCategoryName = ProductCategoryName.Trim();
                obj.UpdatedBy = Session["UserID"].ToString();
                DataSet ds = obj.UpdateProductCategory();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        FormName = "ProductCategoryList";
                        Controller = "Master";

                        TempData["Delete"] = "ProductCategory is Successfully Updated!";
                    }
                    else
                    {
                        //Session["Pk_ProductCategoryId"] = Pk_ProductCategoryId;
                        FormName = "ProductCategoryMaster";
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
        
        #region DeleteCategoryMaster
        public ActionResult DeleteCategoryMaster(string Pk_CategoryId)
        {
            Master obj = new Master();
            try
            {
                obj.DeletedBy = Session["UserID"].ToString();
                obj.Pk_CategoryId = Pk_CategoryId;
                DataSet ds = new DataSet();
                ds = obj.DeleteCategoryMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Success"] = "Category Deleted Successfully";
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
            //ViewBag.saverrormsg = "";
            return RedirectToAction("CategoryList", "Master");
        }
        #endregion

        #region DeleteInterractionMaster
        public ActionResult DeleteInterractionMaster(string PK_InterActionId)
        {
            Master obj = new Master();
            try
            {
                obj.DeletedBy = Session["UserID"].ToString();
                obj.PK_InterActionId = PK_InterActionId;
                DataSet ds = new DataSet();
                ds = obj.DeleteInterractionMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Success"] = "InterAction Deleted Successfully";
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
            //ViewBag.saverrormsg = "";
            return RedirectToAction("InterActionList", "Master");
        }
        #endregion

        #region DeleteDataSourceMaster
        public ActionResult DeleteDataSourceMaster(string Pk_SourceId)
        {
            Master obj = new Master();
            try
            {
                obj.DeletedBy = Session["UserID"].ToString();
                obj.Pk_SourceId = Pk_SourceId;
                DataSet ds = new DataSet();
                ds = obj.DeleteDataSourceMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Success"] = "DataSource Deleted Successfully";
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
            //ViewBag.saverrormsg = "";
            return RedirectToAction("DataSourceList", "Master");
        }
        #endregion

        #region DeleteProspectActivityMaster
        public ActionResult DeleteProspectActivityMaster(string Pk_ActivityId)
        {
            Master obj = new Master();
            try
            {
                obj.DeletedBy = Session["UserID"].ToString();
                obj.Pk_ActivityId = Pk_ActivityId;
                DataSet ds = new DataSet();
                ds = obj.DeleteProspectActivityMaster();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Success"] = "DataSource Deleted Successfully";
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
            //ViewBag.saverrormsg = "";
            return RedirectToAction("ProspectActivityList", "Master");
        }
        #endregion

        #region DeleteBusinessChance
        public ActionResult DeleteBusinessChance(string Pk_BusinessChanceId)
        {
            Master obj = new Master();
            try
            {
                obj.DeletedBy = Session["UserID"].ToString();
                obj.Pk_BusinessChanceId = Pk_BusinessChanceId;
                DataSet ds = new DataSet();
                ds = obj.DeleteBusinessChance();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Success"] = "Business Chance Deleted Successfully";
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
            //ViewBag.saverrormsg = "";
            return RedirectToAction("BusinessChanceList", "Master");
        }
        #endregion

        #region DeleteProductCategory
        public ActionResult DeleteProductCategory(string Pk_ProductCategoryId)
        {
            Master obj = new Master();
            try
            {
                obj.DeletedBy = Session["UserID"].ToString();
                obj.Pk_ProductCategoryId = Pk_ProductCategoryId;
                DataSet ds = new DataSet();
                ds = obj.DeleteProductCategory();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["Success"] = "Product Category Deleted Successfully";
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
            //ViewBag.saverrormsg = "";
            return RedirectToAction("ProductCategoryList", "Master");
        }
        #endregion
    }
}