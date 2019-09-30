using EAMS.Core.IRepositories;
using EAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using EAMS.DB_Contexts;

namespace EAMS.Persistence.Repositories
{
    public class GradeMasterRepository : Repository<GradeMaster>, IGradeMasterRepository
    {
        public GradeMasterRepository(DbContext context) : base(context)
        {

        }
        public IEnumerable<SelectListItem> GetGrades()
        {
            List<SelectListItem> grades = EAMSContext.GradeMstr
                    .OrderBy(n => n.GradeName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.GradeId.ToString(),
                            Text = n.GradeName
                        }).ToList();
            var grdtip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Grade ---"
            };
            grades.Insert(0, grdtip);
            return new SelectList(grades, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}