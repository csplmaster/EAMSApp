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
    public class QualificationMasterRepository : Repository<QualificationMaster>, IQualificationMasterRepository
    {
        public QualificationMasterRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetQualifications()
        {
            List<SelectListItem> qualifications = EAMSContext.QualificationMstrs
                    .OrderBy(n => n.Qualification)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.QualificationId.ToString(),
                            Text = n.Qualification
                        }).ToList();
            //var qualificationtip = new SelectListItem()
            //{
            //    Value = null,
            //    Text = "--- select Qualification ---"
            //};
            //qualifications.Insert(0, qualificationtip);
            return new SelectList(qualifications, "Value", "Text");
        }
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}