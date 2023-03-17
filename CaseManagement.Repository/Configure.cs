using CaseManagement.Repository.AuthData.Interfaces;
using CaseManagement.Repository.AuthData.Repositories;
using CaseManagement.Repository.Interfaces;
using CaseManagement.Repository.Repositories;
using CaseManagement.Repository.RoleBase.Interfaces;
using CaseManagement.Repository.RoleBase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CaseManagement.Repository
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            DAL.Configure.ConfigureServices(services, connectionString);
            //Authenticate Repository and Token options as dependency injection
            services.AddScoped<IAuthenticate, AuthenticateRepository>();
            services.AddScoped<IAppUser, AppUserRepository>();
            services.AddScoped<IPartner, PartnerRepository>();
            services.AddScoped<IState, StateRepository>();
            services.AddScoped<ICity, CityRepository>();
            services.AddScoped<IOrganization, OrganizationRepository>();
            services.AddScoped<ICollective, CollectiveRepository>();
            services.AddScoped<IShg, ShgRepository>();
            services.AddScoped<IDistrict, DistrictRepository>();
            services.AddScoped<IDocumentType, DocumentTypeRepository>();
            services.AddScoped<IBlock, BlockRepository>();
            services.AddScoped<ILookup, LookupRepository>();
            services.AddScoped<IAct, ActRepository>();
            services.AddScoped<ISection, SectionRepository>();
            services.AddScoped<IRole, RoleRepository>();
            services.AddScoped<ILawyerType, LawyerTypeRepository>();
            services.AddScoped<IMember, MemberRepository>();
            services.AddScoped<IPoliceStation, PoliceStationRepository>();
            services.AddScoped<ISurvivor, SurvivorRepository>();
            services.AddScoped<ITrafficker, TraffickerRepository>();
            services.AddScoped<ILegalServiceType, LegalServiceTypeRepository>();
            services.AddScoped<IRescue, RescueRepository>();
            services.AddScoped<ILegalServiceProvider, LegalServiceProviderRepository>();
            services.AddScoped<ILawyer, LawyerRepository>();
            services.AddScoped<IFir, FirRepository>();
            services.AddScoped<ISurvivorTrafficker, SurvivorTraffickerRepository>();
            services.AddScoped<IInvestigation, InvestigationRepository>();
            services.AddScoped<IVc, VcRepository>();
            services.AddScoped<IAhtu, AhtuRepository>();
            services.AddScoped<IPc, PcRepository>();
            services.AddScoped<ISurvivorDocument, SurvivorDocumentRespository>();
            services.AddScoped<IRoleBase, RoleBaseRepository>();
            services.AddScoped<ISurvivorLoan, SurvivorLoanRepository>();
            services.AddScoped<ISurvivorIncome, SurvivorIncomeRepository>();
            services.AddScoped<ISurvivorShelter, SurvivorShelterRepository>();
            services.AddScoped<IShelterHome, ShelterHomeRepository>();
            services.AddScoped<ICitTemplate, CitTemplateRepository>();
            services.AddScoped<IDimension, DimensionRepository>();
            services.AddScoped<IDimensionQuestion, DimensionQuestionRepository>();
            services.AddScoped<ICitDimension, CitDimensionRepository>();
            services.AddScoped<ISurvivorCit, SurvivorCitRepository>();
            services.AddScoped<IPanchayat, PanchayatRepository>();
            services.AddScoped<IVillage, VillageRepository>();
            services.AddScoped<IReport, ReportRepository>();
            services.AddScoped<IAlert, AlertRepository>();
            services.AddScoped<IAlertRules, AlertRulesRepository>();
            services.AddScoped<IDiary, DiaryRepository>();
            services.AddScoped<ISuperAdminReport, SuperAdminReportRepository>();
            services.AddScoped<ISurvivorGrant, SurvivorGrantRepository>();
            services.AddScoped<IChargeSheet, ChargeSheetRepository>();
        }
    }
}