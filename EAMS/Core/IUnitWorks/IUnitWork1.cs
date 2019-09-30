using EAMS.Core.IRepositories;
using System;

namespace EAMS.Core.IUnitWorks
{
    public interface IUnitWork1 : IDisposable
    {
        IEmp1Repository Emp1s { get; }
        ICompanyMasterRepository CompanyMasters { get; }
        IQualificationMasterRepository QualificationMasters { get; }
        IStateMasterRepository StateMasters { get; }
        ICityMasterRepository CityMasters { get; }
        IEmployerDetailsRepository EmployerDetails { get; }
        IVacancyMasterRepository VacancyMasters { get; }
        IPBORSponsorshipRepository PBORSpopnserships { get; }
        IRegistrationESMOffrsRepository Registrations { get; }
        ISainikBoardRepository Sainikboards { get; }
        INotingMasterRepository Notings { get; }
        IRegistrationEAMSJcoRepository RegEAMSJCOs { get; }
        ISponsorDataRepository SponsorDatas { get; }
        IOutcomeDataRepository OutcomeDatas { get; }
        ICorpMasterRepository CorpMasters { get; }
        ITradeMasterRepository TradeMasters { get; }
        IPersonRepository PersonData { get; }
        IGradeMasterRepository GradeMasters { get; }
        int Complete();
        
    }
}
