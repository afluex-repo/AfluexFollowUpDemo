using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AfluexFollowUpDemo.Models
{
    public class ForgotPassword
    {
        public string Pk_Id { get; set; }
        public string LoginId { get; set; }
        public string EmailId { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string CreatedBy { get; set; }


        public DataSet PasswordForget()
        {
            SqlParameter[] para = {new SqlParameter("@LoginId",LoginId),
                                   new SqlParameter("@EmailId",EmailId)};
            DataSet ds = DBHelper.ExecuteQuery("ForgotPassword", para);
            return ds;

        }
    }
}