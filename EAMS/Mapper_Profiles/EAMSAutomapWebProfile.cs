using AutoMapper;
using EAMS.Models;
using EAMS.View_Models;
using System.Collections.Generic;

namespace EAMS.Mapper_Profile
{
    public class EAMSAutomapWebProfile : Profile
    {
        public EAMSAutomapWebProfile()
        {
            CreateMap<Emp1Update_VM, Emp1 > ();
            CreateMap<Emp1, Emp1Update_VM> ();

            CreateMap<CompanyMasterIndexVM, CompanyMaster>();
            CreateMap<CompanyMaster, CompanyMasterIndexVM>();

            CreateMap<CompanyMasterCreateVM, CompanyMaster>();
            CreateMap<CompanyMaster, CompanyMasterCreateVM>();

            CreateMap<CompanyMasterUpdateVM, CompanyMaster>();
            CreateMap<CompanyMaster, CompanyMasterUpdateVM>();

            CreateMap<CompanyMasterDeleteVM, CompanyMaster>();
            CreateMap<CompanyMaster, CompanyMasterDeleteVM>();

            CreateMap<StateMasterVM, StateMaster>();
            CreateMap<StateMaster, StateMasterVM>();

            CreateMap<CityMasterVM, CityMaster>();
            CreateMap<CityMaster, CityMasterVM>();

            CreateMap<EmployerDetailsIndxVM, EmployerDetails>();
            CreateMap<EmployerDetails, EmployerDetailsIndxVM>();

            CreateMap<EmployerDetailsCrtVM, EmployerDetails>();
            CreateMap<EmployerDetails, EmployerDetailsCrtVM>();

            CreateMap<EmployerDetailsUpVM, EmployerDetails>();
            CreateMap<EmployerDetails, EmployerDetailsUpVM>();

            CreateMap<EmployerDetailsDelVM, EmployerDetails>();
            CreateMap<EmployerDetails, EmployerDetailsDelVM>();

            CreateMap<QualificationMasterIndxVM, QualificationMaster>();
            CreateMap<QualificationMaster, QualificationMasterIndxVM>();

            CreateMap<QualificationMasterCrtVM, QualificationMaster>();
            CreateMap<QualificationMaster, QualificationMasterCrtVM>();

            CreateMap<QualificationMasterUpVM, QualificationMaster>();
            CreateMap<QualificationMaster, QualificationMasterUpVM>();

            CreateMap<QualificationMasterDelVM, QualificationMaster>();
            CreateMap<QualificationMaster, QualificationMasterDelVM>();

            CreateMap<RankMaster, RankMasterVM>();
            CreateMap<RankMasterVM, RankMaster>();

            CreateMap<ESMDetailsCrtVM, ESMOfficersDetail>();
            CreateMap<ESMOfficersDetail, ESMDetailsCrtVM>();

            CreateMap<ESMDetailsIndexVM, ESMOfficersDetail>();
            CreateMap<ESMOfficersDetail, ESMDetailsIndexVM>();

            CreateMap<ESMDetailsUpVM, ESMOfficersDetail>();
            CreateMap<ESMOfficersDetail, ESMDetailsUpVM>();

            CreateMap<ESMJcoIndexVM, ESMJcoORsDetail>();
            CreateMap<ESMJcoORsDetail, ESMJcoIndexVM>();

            CreateMap<ESMJcoCrtVM, ESMJcoORsDetail>();
            CreateMap<ESMJcoORsDetail, ESMJcoCrtVM>();

            CreateMap<ESMJcoUpVM, ESMJcoORsDetail>();
            CreateMap<ESMJcoORsDetail, ESMJcoUpVM>();

            CreateMap<PBORsponserDetailsIndxVM, PBORSponsorshipDetail>();
            CreateMap<PBORSponsorshipDetail, PBORsponserDetailsIndxVM>();

            CreateMap<PBORsponserDetailsCrtVM, PBORSponsorshipDetail>();
            CreateMap<PBORSponsorshipDetail, PBORsponserDetailsCrtVM>();

            CreateMap<PBORsponserDetailsUpVM, PBORSponsorshipDetail>();
            CreateMap<PBORSponsorshipDetail, PBORsponserDetailsUpVM>();

            CreateMap<RegsESMOffrsIndexVM, RegistrationESMOffrs>();
            CreateMap<RegistrationESMOffrs, RegsESMOffrsIndexVM>();

            CreateMap<RegsESMOffrsCreateVM, RegistrationESMOffrs>();
            CreateMap<RegistrationESMOffrs, RegsESMOffrsCreateVM>();

            CreateMap<RegsESMOffrsUpdateVM, RegistrationESMOffrs>();
            CreateMap<RegistrationESMOffrs, RegsESMOffrsUpdateVM>();

            CreateMap<SainikBoardIndexVM, SainikBoardDetails>();
            CreateMap<SainikBoardDetails, SainikBoardIndexVM>();

            CreateMap<SainikBoardCreateVM, SainikBoardDetails>();
            CreateMap<SainikBoardDetails, SainikBoardCreateVM>();

            CreateMap<SainikBoardUpdtVM,SainikBoardDetails>();
            CreateMap<SainikBoardDetails, SainikBoardUpdtVM>();

            CreateMap<RegEAMSJcoIndex, RegistrationEAMSJco>();
            CreateMap<RegistrationEAMSJco, RegEAMSJcoIndex>();

            CreateMap<RegEAMSJcoCreate, RegistrationEAMSJco>();
            CreateMap<RegistrationEAMSJco, RegEAMSJcoCreate>();

            CreateMap<RegEAMSJcoUpdate, RegistrationEAMSJco>();
            CreateMap<RegistrationEAMSJco, RegEAMSJcoUpdate>();

            CreateMap<SponsorDataIndexVM, SponsorData>();
            CreateMap<SponsorData, SponsorDataIndexVM>();

            CreateMap<SponsorDataCreateVM, SponsorData>();
            CreateMap<SponsorData, SponsorDataCreateVM>();

            CreateMap<SponsorDataUpdateVM, SponsorData>();
            CreateMap<SponsorData, SponsorDataUpdateVM>();


            CreateMap<ESMJcoORsDetail, JCOORVacancyData>();
            CreateMap<JCOORVacancyData, ESMJcoORsDetail>();

            //CreateMap<SponsorPerDataVM, ESMOfficersDetail>();
            //CreateMap<ESMOfficersDetail, SponsorPerDataVM>();

            CreateMap<OutcomeDataIndexVM, OutcomeData>();
            CreateMap<OutcomeData, OutcomeDataIndexVM>();

            CreateMap<OutcomeDataCreateVM, OutcomeData>();
            CreateMap<OutcomeData, OutcomeDataCreateVM>();

            CreateMap<OutcomeDataUpdateVM, OutcomeData>();
            CreateMap<OutcomeData, OutcomeDataUpdateVM>();           

        }
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<EAMSAutomapWebProfile>();
            });
        }
    }
}