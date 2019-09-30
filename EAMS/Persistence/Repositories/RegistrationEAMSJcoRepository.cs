using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EAMS.Models;
using EAMS.Core.IRepositories;
using EAMS.DB_Contexts;
using System.Data.Entity;
using EAMS.View_Models;

namespace EAMS.Persistence.Repositories
{
    public class RegistrationEAMSJcoRepository : Repository<RegistrationEAMSJco>, IRegistrationEAMSJcoRepository
    {
        public RegistrationEAMSJcoRepository(DbContext context) : base(context)
        {

        }
    }
}