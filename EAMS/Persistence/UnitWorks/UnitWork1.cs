using System;
using EAMS.Core.IRepositories;
using EAMS.Core.IUnitWorks;
using EAMS.DB_Contexts;
using EAMS.Persistence.Repositories;

namespace EAMS.Persistence
{
    public class UnitWork1 : IUnitWork1
    {
        private readonly EAMSContext _context;

        public UnitWork1(EAMSContext context)
        {
            _context = context;
            Emp1s = new Emp1Repository(_context);
            CompanyMasters = new CompanyMasterRepository(_context);
            QualificationMasters = new QualificationMasterRepository(_context);
            StateMasters = new StateMasterRepository(_context);
            CityMasters = new CityMasterRepository(_context);
            EmployerDetails = new EmployerDetailsRepository(_context);
            VacancyMasters = new VacancyMasterRepository(_context);
            RankMasters = new RankMasterRepository(_context);
            ESMDetails = new ESMOfficersDetailRepository(_context);
            ESMJcoDetails = new ESMJcoORsDetailRepository(_context);
            PBORSpopnserships = new PBORSponsorshipRepository(_context);
            Registrations = new RegistrationESMOffrsRepository(_context);
            Sainikboards = new SainikBoardRepository(_context);
            Notings = new NotingMasterRepository(_context);
            RegEAMSJCOs = new RegistrationEAMSJcoRepository(_context);
            SponsorDatas = new SponsorDataRepository(_context);
            OutcomeDatas = new OutcomeDataRepository(_context);
            PersonData = new PersonRepository(_context);
            CorpMasters = new CorpMasterRepository(_context);
            TradeMasters = new TradeMasterRepository(_context);
            GradeMasters = new GradeMasterRepository(_context);
        }

        public ICompanyMasterRepository CompanyMasters { get; private set; }
        public IEmp1Repository Emp1s { get; private set; }
        public IQualificationMasterRepository QualificationMasters { get; private set; }
        public IStateMasterRepository StateMasters { get; private set; }
        public ICityMasterRepository CityMasters { get; private set; }
        public IEmployerDetailsRepository EmployerDetails { get; private set; }
        public IVacancyMasterRepository VacancyMasters { get; private set; }
        public IRankMasterRepository RankMasters { get; private set; }
        public IESMOfficersDetailRepository ESMDetails { get; private set; }
        public IESMJcoORsDetailRepository ESMJcoDetails { get; private set; }
        public IPBORSponsorshipRepository PBORSpopnserships { get; private set; }
        public IRegistrationESMOffrsRepository Registrations { get; private set; }
        public ISainikBoardRepository Sainikboards { get; private set; }
        public INotingMasterRepository Notings { get; private set; }
        public IRegistrationEAMSJcoRepository RegEAMSJCOs { get; private set; }
        public ISponsorDataRepository SponsorDatas { get; private set; }
        public IOutcomeDataRepository OutcomeDatas { get; private set; }
        public IPersonRepository PersonData { get; private set; }
        public ICorpMasterRepository CorpMasters { get; private set; }
        public ITradeMasterRepository TradeMasters { get; private set; }
        public IGradeMasterRepository GradeMasters { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}