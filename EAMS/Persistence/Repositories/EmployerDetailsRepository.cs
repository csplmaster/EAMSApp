using EAMS.Core.IRepositories;
using EAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EAMS.DB_Contexts;

namespace EAMS.Persistence.Repositories
{
    public class EmployerDetailsRepository : Repository<EmployerDetails>, IEmployerDetailsRepository
    {
        public EmployerDetailsRepository(DbContext context) : base(context)
        {
        }
        //public IEnumerable<EmployerDetails> GetProducts(string searchText)
        //{
        //    var result = EAMSContext.Set<EmployerDetails>().ToList();

        //    //if (searchText != null)
        //    //{

        //    //        result = result.Where(x=>x.Branch==searchText || ).ToList();
        //    //    if (!string.IsNullOrEmpty(searchModel.Name))
        //    //        result = result.Where(x => x.Name.Contains(searchModel.Name));
        //    //    if (searchModel.PriceFrom.HasValue)
        //    //        result = result.Where(x => x.Price >= searchModel.PriceFrom);
        //    //    if (searchModel.PriceTo.HasValue)
        //    //        result = result.Where(x => x.Price <= searchModel.PriceTo);
        //    //}
        //    return result;
        //}
        public EAMSContext EAMSContext
        {
            get { return Context as EAMSContext; }
        }
    }
}