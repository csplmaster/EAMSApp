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
    public class RegistrationESMOffrsRepository : Repository<RegistrationESMOffrs>, IRegistrationESMOffrsRepository
    {
        public RegistrationESMOffrsRepository(DbContext context) : base(context)
        {
        }
    }    
}