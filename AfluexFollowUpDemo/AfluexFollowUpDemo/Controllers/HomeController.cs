using AfluexFollowUpDemo.Filter;
using AfluexFollowUpDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

using System.Web.Mvc;

namespace AfluexFollowUpDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult LoginAction(User obj)
        {
            if (obj.LoginId == null)
            {
                ViewBag.errormsg = "";
                TempData["Login"] = "Please Enter LoginId";
                return RedirectToAction("Index");

            }
            if (obj.Password == null)
            {
                ViewBag.errormsg = "";
                TempData["Login"] = "Please Enter Password";
                return RedirectToAction("Index");
            }
            if (obj.LoginId.Trim() == "")
            {
                ViewBag.errormsg = "";
                TempData["Login"] = "Please Enter LoginId";
                return RedirectToAction("Index");

            }
            if (obj.Password.Trim() == "")
            {
                ViewBag.errormsg = "";
                TempData["Login"] = "Please Enter Password";
                return RedirectToAction("Index");

            }

            try
            {

                User Modal = new User();
                DataSet ds = obj.Login();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows[0]["Fk_UserTypeId"].ToString() == "1")
                    {
                        ViewBag.errormsg = "";
                        Session["UserID"] = ds.Tables[0].Rows[0]["Pk_Id"].ToString();
                        Session["LoginID"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Session["Username"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        Session["FK_UserTypeID"] = ds.Tables[0].Rows[0]["Fk_UserTypeId"].ToString();

                        return RedirectToAction("DashBoard", "Home");

                    }

                    if (ds.Tables[0].Rows[0]["Fk_UserTypeId"].ToString() != "1")
                    {
                        ViewBag.errormsg = "";
                        Session["ExecutiveID"] = ds.Tables[0].Rows[0]["Pk_Id"].ToString();
                        Session["LoginID"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Session["Username"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        Session["FK_UserTypeID"] = ds.Tables[0].Rows[0]["Fk_UserTypeId"].ToString();
                        return RedirectToAction("DashBoard", "EmployeeRegistration");

                    }

                    else
                    {
                        ViewBag.errormsg = "";
                        TempData["Login"] = "Incorrect LoginId Or Password";
                        return RedirectToAction("Index");

                    }

                }
                else
                {
                    ViewBag.errormsg = "";
                    TempData["Login"] = "Incorrect LoginId Or Password";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.errormsg = "";
                TempData["Login"] = ex.Message;
                return RedirectToAction("Index");

            }



        }

        public ActionResult DashBoard()
        {
           
            return View();
        }
        public ActionResult ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        [ActionName("ForgetPassword")]
        [OnAction(ButtonName = "btnforget")]
        public ActionResult ChangePassword(ForgotPassword model)
        {
            DataSet ds = model.PasswordForget();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    try
                    {
                        if (model.EmailId != null)
                        {
                            string mailbody = "";

                            mailbody = "Dear Member,<br> your Passoword is : " + ds.Tables[0].Rows[0]["Password"].ToString();
                            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = true,
                                Credentials = new NetworkCredential("developer5.afluex@gmail.com", "Afluex@123")
                            };
                            using (var message = new MailMessage("developer5.afluex@gmail.com", model.EmailId)
                            {
                                IsBodyHtml = true,
                                Subject = "Recover Password",
                                Body = mailbody
                            })
                                smtp.Send(message);
                               TempData["Login"] = "Your Password Has Been Send On your EmailId";

                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    }
                else
                {
                    TempData["Login"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            
            return RedirectToAction("ForgetPassword", "Home");
        }
         

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}