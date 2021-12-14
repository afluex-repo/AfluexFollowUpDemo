using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AfluexFollowUpDemo.Models
{
    public class APIModel
    {
        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public DataSet Login()
            {
                SqlParameter[] para =
                    {
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@Password",Password)
            };
                DataSet ds = DBHelper.ExecuteQuery("LoginProc", para);
                return ds;
            }

        }
        public class Crypto
        {
            public static string Encrypt(string clearText)
            {
                try
                {
                    string EncryptionKey = "ABCDEHJKLMNHBJKOAAAA";
                    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(clearBytes, 0, clearBytes.Length);
                                cs.Close();
                            }
                            clearText = Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
                catch { clearText = ""; }
                return clearText;
            }
            public static string Decrypt(string cipherText)
            {
                try
                {
                    string EncryptionKey = "ABCDEHJKLMNHBJKOAAAA";
                    cipherText = cipherText.Replace(" ", "+");
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    using (Aes encryptor = Aes.Create())
                    {
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            cipherText = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                }
                catch (Exception ex) { cipherText = ""; }
                return cipherText;
            }
        }
        public class ProductRequest
        {
            //public string Pk_CategoryId { get; set; }
            public DataSet ProductCategorylist()
            {
                SqlParameter[] para =
                    {
                      // new SqlParameter("@Pk_CategoryId",Pk_CategoryId)

            };
                DataSet ds = DBHelper.ExecuteQuery("SP_GetProductCategory", para);
                return ds;
            }
        }
        public class CategoryDetails
        {
            public string Pk_CategoryId { get; set; }
            public string CategoryName { get; set; }
        }
        public class SubCategoryDetails
        {
            public string Pk_ProductCategoryId { get; set; }
            public string ProductCategoryName { get; set; }
            public string Pk_CategoryId { get; set; }
        }
        public class SaveProcpect
        {
            public string ContactPerson { get; set; }
            public string ContactEmailId { get; set; }
            public string ContactNo { get; set; }
            public string Fk_IndustryCategoryId { get; set; }
            public string CompanyName { get; set; }
            public string CompanyContactNo { get; set; }
            public string Address { get; set; }
            public string Pincode { get; set; }
            public string Designation { get; set; }
            public string WebSite { get; set; }
            public string SkypeId { get; set; }
            public string FacebookId { get; set; }
            public string LinkedInId { get; set; }
            public string ApproximateEmployee { get; set; }
            public string ApproximateCompanyTurnOver { get; set; }
            /// public string Fk_ProcPectId { get; set; }
            public string FirstInstructionDate { get; set; }
            public string Fk_ExpectedProductCategoryId { get; set; }
            public string Fk_SourceId { get; set; }
            public string Fk_ExecutiveId { get; set; }
            public string Fk_ModeInterActionId { get; set; }
            public string FollowupDate { get; set; }
            public string Description { get; set; }
            public string TwitterId { get; set; }
            public string AddedBy { get; set; }
            public string Pk_ProcpectId { get; set; }
            public DataSet insertProcpect()
            {
                SqlParameter[] para = {
                                      new SqlParameter("@ContactPerson",ContactPerson),
                                      new SqlParameter("@ContactEmailId",ContactEmailId),
                                      new SqlParameter("@ContactNo",ContactNo),
                                      new SqlParameter("@Fk_IndustryCategoryId",Fk_IndustryCategoryId),
                                      new SqlParameter("@CompanyName",CompanyName),
                                      new SqlParameter("@CompanyContactNo",CompanyContactNo),
                                      new SqlParameter("@Address",Address),
                                      new SqlParameter("@Pincode",Pincode),
                                      new SqlParameter("@Designation",Designation),
                                      new SqlParameter("@WebSite",WebSite),
                                      new SqlParameter("@SkypeId",SkypeId),
                                      new SqlParameter("@FacebookId",FacebookId),
                                      new SqlParameter("@TwitterId",TwitterId),
                                      new SqlParameter("@LinkedInId",LinkedInId),
                                      new SqlParameter("@ApproximateEmployee",ApproximateEmployee),
                                      new SqlParameter("@ApproximateCompanyTurnOver",ApproximateCompanyTurnOver),
                                      new SqlParameter("@FirstInstructionDate",FirstInstructionDate),
                                      new SqlParameter("@Fk_ExpectedProductCategoryId",Fk_ExpectedProductCategoryId),
                                      new SqlParameter("@Fk_SourceId",Fk_SourceId),
                                      new SqlParameter("@Fk_ExecutiveId",Fk_ExecutiveId),
                                      new SqlParameter("@Fk_ModeInterActionId",Fk_ModeInterActionId),
                                      new SqlParameter("@FollowupDate",FollowupDate),
                                      new SqlParameter("@Description",Description),
                                      new SqlParameter("@AddedBy",AddedBy)
                                  };
                DataSet ds = DBHelper.ExecuteQuery("InsertProcpectLeads", para);
                return ds;
            }
            public static string ConvertToSystemDate(string InputDate, string InputFormat)
            {
                string DateString = "";
                DateTime Dt;

                string[] DatePart = (InputDate).Split(new string[] { "-", @"/" }, StringSplitOptions.None);

                if (InputFormat == "dd-MMM-yyyy" || InputFormat == "dd/MMM/yyyy" || InputFormat == "dd/MM/yyyy" || InputFormat == "dd-MM-yyyy")
                {
                    string Day = DatePart[0];
                    string Month = DatePart[1];
                    string Year = DatePart[2];

                    if (Month.Length > 2)
                        DateString = InputDate;
                    else
                        DateString = Month + "/" + Day + "/" + Year;
                }
                else if (InputFormat == "MM/dd/yyyy" || InputFormat == "MM-dd-yyyy")
                {
                    DateString = InputDate;
                }
                else
                {
                    throw new Exception("Invalid Date");
                }

                try
                {
                    //Dt = DateTime.Parse(DateString);
                    //return Dt.ToString("MM/dd/yyyy");
                    return DateString;
                }
                catch
                {
                    throw new Exception("Invalid Date");
                }
            }
        }
        public class ProspectList
        {
            public string Pk_ProcpectId { get; set; }
            public string ContactPerson { get; set; }
            public string ContactNo { get; set; }
            public string CompanyName { get; set; }
            public string EmployeeId { get; set; }
            public DataSet ProspectDetails()
            {
                SqlParameter[] para = {
                                      new SqlParameter("@Pk_ProcpectId", Pk_ProcpectId),
                                      new SqlParameter("@ContactPerson", ContactPerson),
                                      new SqlParameter("@ContactNo", ContactNo),
                                      new SqlParameter("@CompanyName", CompanyName),
                                     new SqlParameter("@EmployeeId",EmployeeId)

                                  };
                DataSet ds = DBHelper.ExecuteQuery("GetProspectList", para);
                return ds;
            }
        }

        public class ProspectLst
        {
            public string Pk_ProcpectId { get; set; }
            public string ContactEmailId { get; set; }
            public string Fk_IndustryCategoryId { get; set; }
            public string CompanyContactNo { get; set; }
            public string Address { get; set; }
            public string ContactPerson { get; set; }
            public string CompanyName { get; set; }
            public string ContactNo { get; set; }
        }
    }
}