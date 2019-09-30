using System;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using EAMS.Persistence;
using EAMS.DB_Contexts;
using EAMS.View_Models;

namespace EAMS.Controllers
{
    public class ESMJcoExcelController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EAMSConString"].ConnectionString);
        OleDbConnection Econ;
        // GET: ESMJcoExcel
        
        public ActionResult ExcelFileUpload()
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                ViewBag.Companies = unitOfWork.CompanyMasters.GetCompanies();
                ViewBag.SainikBoards = unitOfWork.Sainikboards.GetSainikboard();
                unitOfWork.Complete();
                return View();
            }
        }
        [HttpPost]
        public ActionResult ExcelFileUpload(ESMJcoExcelUploadVM objESMJcoExl)
        {
            foreach (HttpPostedFileBase file in objESMJcoExl.files)
            {
                if (file != null)
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string filepath = "/excelfolder/" + filename;
                    file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
                    InsertExceldata(filepath, filename, objESMJcoExl.CompanyId, objESMJcoExl.VacancyId, objESMJcoExl.SbId, objESMJcoExl.ServiceType);
                }
            }
            return RedirectToAction("ExcelFileUpload");
        }
        public JsonResult GetJobPosts(long companyid)
        {
            using (var unitOfWork = new UnitWork1(new EAMSContext()))
            {
                var jobpostsdata = unitOfWork.VacancyMasters.GetPostsByCompanyId(companyid);
                unitOfWork.Complete();
                return Json(jobpostsdata, JsonRequestBehavior.AllowGet);
            }
        }

        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";");
            Econ = new OleDbConnection(constr);
        }
        private void InsertExceldata(string fileepath, string filename, long cmpId, long postId, long sbId, string ServType)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("CompanyId");
            dt.Columns.Add("VacancyId");
            dt.Columns.Add("SbId");
            foreach (DataRow row in dt.Rows)
            {
                //need to set value to NewColumn column
                row["CompanyId"] = cmpId;   // or set it to some other value
                row["VacancyId"] = postId;
                row["SbId"] = sbId;
            }

            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            if (ServType == "Jco")
            {
                MapField_ESMJcoOR(objbulk);
            }
            else if (ServType == "Ofcr")
            {
                MapField_ESMOfficer(objbulk);
            }

            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();
        }

        private static void MapField_ESMJcoOR(SqlBulkCopy objbulk)
        {
            objbulk.DestinationTableName = "ESMJcoORsDetails";
            //objbulk.ColumnMappings.Add("EsmId", "EsmId");
            objbulk.ColumnMappings.Add("CompanyId", "CompanyId");
            objbulk.ColumnMappings.Add("VacancyId", "VacancyId");
            objbulk.ColumnMappings.Add("SbId", "SbId");
            objbulk.ColumnMappings.Add("ServiceNo", "ServiceNo");
            objbulk.ColumnMappings.Add("Rank", "RankId");
            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("DateofBirth", "DateofBirth");
            objbulk.ColumnMappings.Add("Corps", "Corps");
            objbulk.ColumnMappings.Add("Trade", "Trade");
            objbulk.ColumnMappings.Add("Category", "Category");
            objbulk.ColumnMappings.Add("Qualification", "QualificationId");
            objbulk.ColumnMappings.Add("WorkExp", "WorkExp");
            objbulk.ColumnMappings.Add("Address", "Address");
            objbulk.ColumnMappings.Add("ContactNo", "ContactNo");
            objbulk.ColumnMappings.Add("EmailId", "EmailId");
        }
        private static void MapField_ESMOfficer(SqlBulkCopy objbulk)
        {
            objbulk.DestinationTableName = "ESMOfficersDetails";
            objbulk.ColumnMappings.Add("EsmId", "EsmId");
            objbulk.ColumnMappings.Add("Company", "CompanyId");
            objbulk.ColumnMappings.Add("PostName", "PostName");
            objbulk.ColumnMappings.Add("ServiceNo", "ServiceNo");
            objbulk.ColumnMappings.Add("Rank", "RankId");
            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("DgrRegistrationNo", "DgrRegistrationNo");
            objbulk.ColumnMappings.Add("DateofBirth", "DateofBirth");
            objbulk.ColumnMappings.Add("CommisionDate", "CommisionDate");
            objbulk.ColumnMappings.Add("RetirementDate", "RetirementDate");
            objbulk.ColumnMappings.Add("Qualification", "QualificationId");
            objbulk.ColumnMappings.Add("Address", "Address");
            objbulk.ColumnMappings.Add("ContactNo", "ContactNo");
            objbulk.ColumnMappings.Add("Email", "EmailId");
        }
        private static void MapFieldExcelToSql2(SqlBulkCopy objbulk)
        {
            objbulk.DestinationTableName = "ESMJcoORsDetails2";
            //objbulk.ColumnMappings.Add("Ser No.", "EsmId");
            //objbulk.ColumnMappings.Add("Service No.", "CompanyId");
            objbulk.ColumnMappings.Add("Service No.", "ServiceNo");
            objbulk.ColumnMappings.Add("Rank", "Rank");
            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("Date of Birth", "DOB");
            objbulk.ColumnMappings.Add("Corps", "Corps");
            objbulk.ColumnMappings.Add("Trade", "Trade");
            objbulk.ColumnMappings.Add("Category (SC/ST/OBC/UR)", "Caste");
            objbulk.ColumnMappings.Add("Qualification acquired by the ESM as required by the Principal Employer", "Qualification");
            objbulk.ColumnMappings.Add("Work Experience as required by the Principal Employer", "WorkExperience");
            objbulk.ColumnMappings.Add("Address", "Address");
            //objbulk.ColumnMappings.Add("Contact No. & E-mail ID", "Category");
            objbulk.ColumnMappings.Add("Contact No.", "ContactNo");
            objbulk.ColumnMappings.Add("E-mail ID", "EmailId");
            objbulk.ColumnMappings.Add("Location Preference (to be filled only in case multiple locations available", "Location");
        }
    }
}