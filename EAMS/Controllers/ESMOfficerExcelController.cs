using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAMS.Models;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace EAMS.Controllers
{
    public class ESMOfficerExcelController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EAMSConString"].ConnectionString);
        OleDbConnection Econ;
        // GET: ESMOfficerExcel
        public ActionResult Index()
        {
            ViewBag.OfficerList = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder"), filename));
            InsertExceldata(filepath, filename);
            return View();
        }        
        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";");
            Econ = new OleDbConnection(constr);
        }
        private void InsertExceldata(string fileepath, string filename)
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
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
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
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();
        }

        // GET: ESMOfficerExcel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ESMOfficerExcel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESMOfficerExcel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ESMOfficerExcel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ESMOfficerExcel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ESMOfficerExcel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ESMOfficerExcel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
