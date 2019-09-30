using EAMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EAMS.DB_Contexts
{
    public class EAMSContext : DbContext
    {
        public EAMSContext() : base("EAMSConString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EAMSContext, EAMS.Migrations.Configuration>());
        }

        public virtual DbSet<CompanyMaster> CompanyMstrs { get; set; }
        public virtual DbSet<QualificationMaster> QualificationMstrs { get; set; }
        public virtual DbSet<StateMaster> StateMstrs { get; set; }
        public virtual DbSet<CityMaster> CityMstrs { get; set; }
        public virtual DbSet<EmployerDetails> EmployerDtls { get; set; }
        public virtual DbSet<VacancyMaster> VacancyMstrs { get; set; }
        public virtual DbSet<RankMaster> RankMstrs { get; set; }
        public virtual DbSet<CorpMaster> CorpMstrs { get; set; }
        public virtual DbSet<TradeMaster> TradeMstrs { get; set; }
        public virtual DbSet<OutcomeData> Outcomedatas { get; set; }
        public virtual DbSet<ESMOfficersDetail> ESMDetails { get; set; }
        public virtual DbSet<ESMJcoORsDetail> ESMJcoDetails { get; set; }
        public virtual DbSet<PBORSponsorshipDetail> PBORSponserships { get; set; }
        public virtual DbSet<RegistrationESMOffrs> RegistrationESMOffrs { get; set; }
        public virtual DbSet<SainikBoardDetails> SainikBoardMasters { get; set; }
        public virtual DbSet<NotingMaster> NotingMasters { get; set; }
        public virtual DbSet<JCOEASMRegistration> JCOEAMSRegistrations { get; set; }
        public virtual DbSet<RegistrationEAMSJco> RegEAMSJcos { get; set; }
        public virtual DbSet<SponsorData> Sponsdatas { get; set; }
        public virtual DbSet<GradeMaster> GradeMstr { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<QualificationMaster>()
                .HasMany(t => t.iVacancyDesirable).WithMany(t => t.iQualificationDesirables).Map(m =>
                {
                    m.ToTable("QualificationDesirable", "dbo");
                    m.MapLeftKey("QualificationId");
                    m.MapRightKey("VacancyId");
                });
            modelBuilder.Entity<QualificationMaster>()
            .HasMany(t => t.iVacancyEssential).WithMany(t => t.iQualificationEssentials).Map(m =>
            {
                m.ToTable("QualificationEssential", "dbo");
                m.MapLeftKey("QualificationId");
                m.MapRightKey("VacancyId");
            });
            modelBuilder.Entity<ESMOfficersDetail>()
                .HasMany(t => t.iSponsorDatas).WithMany(t => t.iESMOffrDetails).Map(m =>
                {
                    m.ToTable("SponsorESMOffrs", "dbo");
                    m.MapLeftKey("EsmId");
                    m.MapRightKey("SponsorId");
                });
            modelBuilder.Entity<ESMJcoORsDetail>()
              .HasMany(t => t.iSponsorDatas).WithMany(t => t.iESMJcoDetails).Map(m =>
              {
                  m.ToTable("SponsorJcoDetails", "dbo");
                  m.MapLeftKey("EsmId");
                  m.MapRightKey("SponsorId");
              });
        }

    }
}