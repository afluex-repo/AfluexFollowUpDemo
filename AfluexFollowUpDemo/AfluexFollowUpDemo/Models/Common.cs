﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfluexFollowUpDemo.Models
{
    public class Common
    {
        public List<Lead> lstnextLead { get; set; }

        public string Pk_Id { get; set; }
        public string Fk_ExecutiveId { get; set; }
        public string PK_InterActionId { get; set; }
        public string Fk_ModeInterActionId { get; set; }
        public string Pk_SourceId { get; set; }
        public string Fk_SourceId { get; set; }
        public string Pk_ProductCategoryId { get; set; }
        public string Fk_ExpectedProductCategoryId { get; set; }
        public string FirstInstructionDate { get; set; }
        public string CompanyContactNo { get; set; }
        public string Pk_LeadeId { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string FollowupDate { get; set; }
        public string PrevioussDate { get; set; }
        public string Description { get; set; }
        public string ContactNo { get; set; }
        public string ContactEmailId { get; set; }
        public string ContactPerson { get; set; }
        public string Prospect { get; set; }
        public string Pk_ProcpectId { get; set; }
        public string Fk_ProcpectId { get; set; }
        public List<Lead> ddlProspect { get; set; }
        public List<Lead> ddlProductCategory { get; set; }
        public List<Lead> ddlDataSource { get; set; }
        public List<Lead> ddlName { get; set; }
        public List<Lead> ddlInterAction { get; set; }
        public List<Lead> lstLead { get; set; }
        public List<Lead> lstpending { get; set; }
        public string EmployeeId { get; set; }
    }
}