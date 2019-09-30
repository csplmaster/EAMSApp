using EAMS.Core.IRepositories;
using EAMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using EAMS.DB_Contexts;


namespace EAMS.Persistence.Repositories
{
    public class PersonRepository: Repository<PersonModel>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}