using System;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AfluexFollowUpDemo;
using System.Web.Http;
using System.Data;
using System.IO;
using System.Web;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static AfluexFollowUpDemo.Models.APIModel;
using System.Web.Script.Serialization;

namespace AluexFollowUpDemo.Controllers
{
    public class WebAPIController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(LoginModel model)
        {
            try
            {
                DataSet ds = model.Login();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {

                        return Request.CreateResponse(HttpStatusCode.OK,
                            new
                            {
                                StatusCode = HttpStatusCode.OK,
                                Message = "Login Successful",
                                Data = new
                                {
                                    PK_UserId = ds.Tables[0].Rows[0]["Pk_Id"].ToString(),
                                    LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString(),
                                    Name = ds.Tables[0].Rows[0]["Name"].ToString(),
                                    Password = ds.Tables[0].Rows[0]["Password"].ToString(),
                                    EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString(),
                                    Fk_UserTypeId = ds.Tables[0].Rows[0]["Fk_UserTypeId"].ToString(),
                                    UserName = ds.Tables[0].Rows[0]["UserName"].ToString(),
                                    Admin = ds.Tables[0].Rows[0]["Admin"].ToString(),

                                }
                            });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,
                          new
                          {
                              StatusCode = HttpStatusCode.InternalServerError,
                              //  Message = "Error: " + ds.Tables[0].Rows[0]["ErrorMessage"].ToString(),
                              Message = "Invalid User ID  and Password",

                          });
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                         new
                         {
                             StatusCode = HttpStatusCode.InternalServerError,
                             // Message = "Error: ",
                             Message = "Invalid User ID  and Password",
                         });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    new
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        // Message = "Error: " + ex.Message,
                        Message = "Invalid User ID  and Password",

                    });
            }
        }
        [Route("api/WebAPI/ProductCategoryList")]
        [HttpPost]
        public HttpResponseMessage ProductCategoryList(ProductRequest objreports)
        {
            List<CategoryDetails> lst = new List<CategoryDetails>();
            List<SubCategoryDetails> lst1 = new List<SubCategoryDetails>();
            DataSet ds = objreports.ProductCategorylist();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    CategoryDetails obj = new CategoryDetails();
                    obj.Pk_CategoryId = r["Pk_CategoryId"].ToString();
                    obj.CategoryName = r["CategoryName"].ToString();
                    lst.Add(obj);
                }
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[1].Rows)
                {
                    SubCategoryDetails obj = new SubCategoryDetails();
                    obj.Pk_ProductCategoryId = r["Pk_ProductCategoryId"].ToString();
                    obj.ProductCategoryName = r["ProductCategoryName"].ToString();
                    lst1.Add(obj);
                }
                return Request.CreateResponse(HttpStatusCode.OK,
              new
              {
                  StatusCode = HttpStatusCode.OK,
                  Message = "Record Found",
                  lstCategory = lst,
                  lstSubCategory = lst1,
              });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,
             new
             {
                 StatusCode = HttpStatusCode.InternalServerError,
                 Message = "Record Not Found",
                 lstSubCategory= "Record Not Found"
             });
            }
        }
    }
}



