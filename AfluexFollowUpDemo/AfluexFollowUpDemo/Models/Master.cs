using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AfluexFollowUpDemo.Models
{
    public class Master
    {

        public string Side { get; set; }
        public string SiteImage { get; set; }
        public string SiteOwner { get; set; }
        public string Comments { get; set; }
        public string CartRate { get; set; }
        public string Quantity { get; set; }
        public string Facing { get; set; }
        public string SiteID { get; set; }
        public string VendorID { get; set; }
        public string Rational { get; set; }
        public string Location { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string ActivityName { get; set; }
        public string Pk_ActivityId { get; set; }
        public string ProductCategoryName { get; set; }
        public string Pk_ProductCategoryId { get; set; }
        public string Area { get; set; }
        public string SiteName { get; set; }
        public string Pk_CategoryId { get; set; }
        public string ChanceName { get; set; }
        public string Pk_BusinessChanceId { get; set; }
        public string SourceName { get; set; }
        public string Pk_SourceId { get; set; }
        public string PK_InterActionId { get; set; }
        public List<Master> lstChance { get; set; }
        public List<Master> lstProductCategory { get; set; }
        public List<Master> lstActivity { get; set; }
        public List<Master> lstSource { get; set; }
        public List<Master> lstCategory { get; set; }
        public List<Master> lstSites { get; set; }
        public List<Master> lstInterAction { get; set; }
        public DataTable dtSiteMaster { get; set; }
        public string MediaTypeID { get; set; }
        public string MediaTypeName { get; set; }
        public string MediaVehicleName { get; set; }
        public string InterActionName { get; set; }
        public string MediaVehicleID { get; set; }
        public string ServiceId { get; set; }
        public string HSNCode { get; set; }
        public string ServiceName { get; set; }
        public string CGST { get; set; }
        public string CategoryName { get; set; }
        public string IGST { get; set; }
        public string SGST { get; set; }
        public string DateFormat { get; set; }
        public string AddedBy { get; set; }
        public String UpdatedBy { get; set; }
        public String DeletedBy { get; set; }

        public DataSet ListDataSource()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_SourceId", Pk_SourceId) };
            DataSet ds = DBHelper.ExecuteQuery("ListDataSource", param);
            return ds;
        }
        public DataSet InsertDataSource()
        {
            SqlParameter[] param = {new SqlParameter("@SourceName",SourceName),
                                   new SqlParameter("@AddedBy",AddedBy)};
            DataSet ds = DBHelper.ExecuteQuery("InsertDataSource", param);
            return ds;
        }
        public DataSet UpdateDataSource()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_SourceId", Pk_SourceId),
                                   new SqlParameter("@SourceName",SourceName),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)};
            DataSet ds = DBHelper.ExecuteQuery("UpdateDataSource", param);
            return ds;
        }
        public DataSet ListInterAction()
        {
            SqlParameter[] param = { new SqlParameter("@PK_InterActionId", PK_InterActionId) };
            DataSet ds = DBHelper.ExecuteQuery("ListInterAction", param);
            return ds;
        }
        public DataSet UpdateInterAction()
        {
            SqlParameter[] param = { new SqlParameter("@PK_InterActionId", PK_InterActionId),
                                   new SqlParameter("@InterActionName",InterActionName),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)};
            DataSet ds = DBHelper.ExecuteQuery("UpdateInterAction", param);
            return ds;
        }
        public DataSet InsertCategory()
        {
            SqlParameter[] param = {new SqlParameter("@CategoryName",CategoryName),
                                   new SqlParameter("@AddedBy",AddedBy)};
            DataSet ds = DBHelper.ExecuteQuery("InsertCategory", param);
            return ds;
        }
        public DataSet ListCategory()
        {
            SqlParameter[] param = { new SqlParameter("@PK_CategoryId", Pk_CategoryId) };
            DataSet ds = DBHelper.ExecuteQuery("ListCategory", param);
            return ds;
        }
        public DataSet ListProductCategory()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_ProductCategoryId", Pk_ProductCategoryId) };
            DataSet ds = DBHelper.ExecuteQuery("GetProductList", param);
            return ds;
        }
        public DataSet UpdateCategory()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_CategoryId", Pk_CategoryId),
                                   new SqlParameter("@CategoryName",CategoryName),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)};
            DataSet ds = DBHelper.ExecuteQuery("UpdateCategory", param);
            return ds;
        }

        public DataSet InsertInterAction()
        {
            SqlParameter[] param = {new SqlParameter("@InterActionName",InterActionName),
                                   new SqlParameter("@AddedBy",AddedBy)};
            DataSet ds = DBHelper.ExecuteQuery("InsertInterAction", param);
            return ds;
        }
        public DataSet InsertProspectActivity()
        {
            SqlParameter[] param = {new SqlParameter("@ActivityName",ActivityName),
                                   new SqlParameter("@AddedBy",AddedBy)};
            DataSet ds = DBHelper.ExecuteQuery("InsertProspectActivity", param);
            return ds;
        }
        public DataSet ListActivity()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_ActivityId", Pk_ActivityId) };
            DataSet ds = DBHelper.ExecuteQuery("ListActivity", param);
            return ds;
        }
        public DataSet UpdateActivity()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_ActivityId", Pk_ActivityId),
                                   new SqlParameter("@ActivityName",ActivityName),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)};
            DataSet ds = DBHelper.ExecuteQuery("UpdateProspectActivity", param);
            return ds;
        }

        public DataSet ListBusinessChance()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_BusinessChanceId", Pk_BusinessChanceId) };
            DataSet ds = DBHelper.ExecuteQuery("ListBusinessChance", param);
            return ds;
        }
        public DataSet InsertBusinessChance()
        {
            SqlParameter[] param = {new SqlParameter("@ChanceName",ChanceName),
                                   new SqlParameter("@AddedBy",AddedBy)};
            DataSet ds = DBHelper.ExecuteQuery("InsertBusinessChance", param);
            return ds;
        }

        public DataSet UpdateBusinessChance()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_BusinessChanceId", Pk_BusinessChanceId),
                                   new SqlParameter("@ChanceName",ChanceName),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)};
            DataSet ds = DBHelper.ExecuteQuery("UpdateBusiness", param);
            return ds;
        }
        public DataSet ExpectedProductCategoryInsert()
        {
            SqlParameter[] param = {new SqlParameter("@ProductCategoryName",ProductCategoryName),
                                   new SqlParameter("@AddedBy",AddedBy)};
            DataSet ds = DBHelper.ExecuteQuery("ExpectedProductCategoryInsert", param);
            return ds;
        }
        public DataSet UpdateProductCategory()
        {
            SqlParameter[] param = { new SqlParameter("@Pk_ProductCategoryId", Pk_ProductCategoryId),
                                   new SqlParameter("@ProductCategoryName",ProductCategoryName),
                                   new SqlParameter("@UpdatedBy",UpdatedBy)};
            DataSet ds = DBHelper.ExecuteQuery("UpdateExpectedProductCategory", param);
            return ds;
        }
        
        public DataSet DeleteCategoryMaster()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_CategoryId", Pk_CategoryId),
                new SqlParameter("@DeletedBy", DeletedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteCategory", para);
            return ds;

        }

        public DataSet DeleteInterractionMaster()
        {
            SqlParameter[] para = { new SqlParameter("@PK_InterActionId", PK_InterActionId),
                new SqlParameter("@DeletedBy", DeletedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteInterractionMode", para);
            return ds;

        }

        public DataSet DeleteDataSourceMaster()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_SourceId", Pk_SourceId),
                new SqlParameter("@DeletedBy", DeletedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteDataSource", para);
            return ds;

        }

        public DataSet DeleteProspectActivityMaster()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_ActivityId", Pk_ActivityId),
                new SqlParameter("@DeletedBy", DeletedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteProspectActivity", para);
            return ds;

        }

        public DataSet DeleteBusinessChance()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_BusinessChanceId", Pk_BusinessChanceId),
                new SqlParameter("@DeletedBy", DeletedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteBusinessChance", para);
            return ds;

        }

        public DataSet DeleteProductCategory()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_ProductCategoryId", Pk_ProductCategoryId),
                new SqlParameter("@DeletedBy", DeletedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("DeleteProductCategory", para);
            return ds;

        }
    }
}
