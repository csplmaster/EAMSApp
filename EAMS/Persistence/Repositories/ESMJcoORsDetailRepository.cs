using EAMS.Core.IRepositories;
using EAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace EAMS.Persistence.Repositories
{
    public class ESMJcoORsDetailRepository : Repository<ESMJcoORsDetail>, IESMJcoORsDetailRepository
    {
        public ESMJcoORsDetailRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetESMs()
        {
            throw new NotImplementedException();
        }
    }
}