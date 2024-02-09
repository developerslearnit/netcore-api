using IbsRestApi.Entities.IbsMdm;
using Microsoft.EntityFrameworkCore;

namespace IbsRestApi.Persistence;

public partial class MdmContext : DbContext
{
    public MdmContext()
    {
    }

    public MdmContext(DbContextOptions<MdmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActLog> ActLogs { get; set; } = null!;
    public virtual DbSet<ActLogM> ActLogMs { get; set; } = null!;
    public virtual DbSet<AppBranch> AppBranches { get; set; } = null!;
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
    public virtual DbSet<AuditTrail> AuditTrails { get; set; } = null!;
    public virtual DbSet<CorporateActionDetail> CorporateActionDetails { get; set; } = null!;
    public virtual DbSet<CorporateActionMaster> CorporateActionMasters { get; set; } = null!;
    public virtual DbSet<CurrencyAccountMapping> CurrencyAccountMappings { get; set; } = null!;
    public virtual DbSet<CustomerRiskProfile> CustomerRiskProfiles { get; set; } = null!;
    public virtual DbSet<CustomerRiskProfileDetail> CustomerRiskProfileDetails { get; set; } = null!;
    public virtual DbSet<EconomicSector> EconomicSectors { get; set; } = null!;
    public virtual DbSet<GsmValidator> GsmValidators { get; set; } = null!;
    public virtual DbSet<IReport4MoneyBook> IReport4MoneyBooks { get; set; } = null!;
    public virtual DbSet<IReport4MoneyBookParameter> IReport4MoneyBookParameters { get; set; } = null!;
    public virtual DbSet<IReport4Moneytor> IReport4Moneytors { get; set; } = null!;
    public virtual DbSet<IReport4MoneytorParameter> IReport4MoneytorParameters { get; set; } = null!;
    public virtual DbSet<IReportGroup4MoneyBook> IReportGroup4MoneyBooks { get; set; } = null!;
    public virtual DbSet<IReportGroup4Moneytor> IReportGroup4Moneytors { get; set; } = null!;
    public virtual DbSet<IbsAccountStatementRequest> IbsAccountStatementRequests { get; set; } = null!;
    public virtual DbSet<IbsAgentMarketer> IbsAgentMarketers { get; set; } = null!;
    public virtual DbSet<IbsApplication> IbsApplications { get; set; } = null!;
    public virtual DbSet<IbsAuditLog> IbsAuditLogs { get; set; } = null!;
    public virtual DbSet<IbsBank> IbsBanks { get; set; } = null!;
    public virtual DbSet<IbsBankSortCode> IbsBankSortCodes { get; set; } = null!;
    public virtual DbSet<IbsBirthdayMessage> IbsBirthdayMessages { get; set; } = null!;
    public virtual DbSet<IbsBranch> IbsBranches { get; set; } = null!;
    public virtual DbSet<IbsCauseOfDeath> IbsCauseOfDeaths { get; set; } = null!;
    public virtual DbSet<IbsClientType> IbsClientTypes { get; set; } = null!;
    public virtual DbSet<IbsCountry> IbsCountries { get; set; } = null!;
    public virtual DbSet<IbsCurrency> IbsCurrencies { get; set; } = null!;
    public virtual DbSet<IbsEmployer> IbsEmployers { get; set; } = null!;
    public virtual DbSet<IbsExcRate> IbsExcRates { get; set; } = null!;
    public virtual DbSet<IbsHospital> IbsHospitals { get; set; } = null!;
    public virtual DbSet<IbsIncomeRange> IbsIncomeRanges { get; set; } = null!;
    public virtual DbSet<IbsLgarea> IbsLgareas { get; set; } = null!;
    public virtual DbSet<IbsNotification> IbsNotifications { get; set; } = null!;
    public virtual DbSet<IbsNotifyClass> IbsNotifyClasses { get; set; } = null!;
    public virtual DbSet<IbsOccupation> IbsOccupations { get; set; } = null!;
    public virtual DbSet<IbsPaymentChannelBankAccount> IbsPaymentChannelBankAccounts { get; set; } = null!;
    public virtual DbSet<IbsPeopleAccountSignatory> IbsPeopleAccountSignatories { get; set; } = null!;
    public virtual DbSet<IbsPeopleAssociationMember> IbsPeopleAssociationMembers { get; set; } = null!;
    public virtual DbSet<IbsPeopleBankAccount> IbsPeopleBankAccounts { get; set; } = null!;
    public virtual DbSet<IbsPeopleContactPerson> IbsPeopleContactPeople { get; set; } = null!;
    public virtual DbSet<IbsPeopleDirector> IbsPeopleDirectors { get; set; } = null!;
    public virtual DbSet<IbsPeopleEmployer> IbsPeopleEmployers { get; set; } = null!;
    public virtual DbSet<IbsPeopleJointMember> IbsPeopleJointMembers { get; set; } = null!;
    public virtual DbSet<IbsPeopleLien> IbsPeopleLiens { get; set; } = null!;
    public virtual DbSet<IbsPeopleNextOfKin> IbsPeopleNextOfKins { get; set; } = null!;
    public virtual DbSet<IbsPeopleRiskProfile> IbsPeopleRiskProfiles { get; set; } = null!;
    public virtual DbSet<IbsPerson> IbsPeople { get; set; } = null!;
    public virtual DbSet<IbsPfa> IbsPfas { get; set; } = null!;
    public virtual DbSet<IbsPlaceOfBirth> IbsPlaceOfBirths { get; set; } = null!;
    public virtual DbSet<IbsPostCode> IbsPostCodes { get; set; } = null!;
    public virtual DbSet<IbsProductLine> IbsProductLines { get; set; } = null!;
    public virtual DbSet<IbsRegion> IbsRegions { get; set; } = null!;
    public virtual DbSet<IbsReligion> IbsReligions { get; set; } = null!;
    public virtual DbSet<IbsState> IbsStates { get; set; } = null!;
    public virtual DbSet<IbsStatementType> IbsStatementTypes { get; set; } = null!;
    public virtual DbSet<IbsTitle> IbsTitles { get; set; } = null!;
    public virtual DbSet<IbsTransactionClass> IbsTransactionClasses { get; set; } = null!;
    public virtual DbSet<IdentifyPeopleWith> IdentifyPeopleWiths { get; set; } = null!;
    public virtual DbSet<InterfaceManager> InterfaceManagers { get; set; } = null!;
    public virtual DbSet<KycRiskProfile> KycRiskProfiles { get; set; } = null!;
    public virtual DbSet<Location> Locations { get; set; } = null!;
    public virtual DbSet<Menu> Menus { get; set; } = null!;
    public virtual DbSet<MessageServer> MessageServers { get; set; } = null!;
    public virtual DbSet<NatureOfbusiness> NatureOfbusinesses { get; set; } = null!;
    public virtual DbSet<Notification> Notifications { get; set; } = null!;
    public virtual DbSet<NotificationModuleUserGroup> NotificationModuleUserGroups { get; set; } = null!;
    public virtual DbSet<OnlineUser> OnlineUsers { get; set; } = null!;
    public virtual DbSet<OnlineUserAccount> OnlineUserAccounts { get; set; } = null!;
    public virtual DbSet<PasswordChangeHistory> PasswordChangeHistories { get; set; } = null!;
    public virtual DbSet<PasswordResetRequest> PasswordResetRequests { get; set; } = null!;
    public virtual DbSet<ProfilePicture> ProfilePictures { get; set; } = null!;
    public virtual DbSet<ReadNotification> ReadNotifications { get; set; } = null!;
    public virtual DbSet<ReceiptType> ReceiptTypes { get; set; } = null!;
    public virtual DbSet<RelationShip> RelationShips { get; set; } = null!;
    public virtual DbSet<RiskChekList> RiskChekLists { get; set; } = null!;
    public virtual DbSet<SentUserAccount> SentUserAccounts { get; set; } = null!;
    public virtual DbSet<SignatoryClassOld> SignatoryClassOlds { get; set; } = null!;
    public virtual DbSet<SignatoryOld> SignatoryOlds { get; set; } = null!;
    public virtual DbSet<SignatoryWorkFlowOld> SignatoryWorkFlowOlds { get; set; } = null!;
    public virtual DbSet<Smtpsetting> Smtpsettings { get; set; } = null!;
    public virtual DbSet<SourceOfFund> SourceOfFunds { get; set; } = null!;
    public virtual DbSet<StatusMeaning> StatusMeanings { get; set; } = null!;
    public virtual DbSet<Tblist> Tblists { get; set; } = null!;
    public virtual DbSet<Tbprice> Tbprices { get; set; } = null!;
    public virtual DbSet<TmpBorrowList> TmpBorrowLists { get; set; } = null!;
    public virtual DbSet<TmpPrtCtbIdlist> TmpPrtCtbIdlists { get; set; } = null!;
    public virtual DbSet<TmpPrtlist> TmpPrtlists { get; set; } = null!;
    public virtual DbSet<UserApplication> UserApplications { get; set; } = null!;
    public virtual DbSet<UserBranch> UserBranches { get; set; } = null!;
    public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;
    public virtual DbSet<ValBrkDwn> ValBrkDwns { get; set; } = null!;
    public virtual DbSet<VfdBankApierrorLog> VfdBankApierrorLogs { get; set; } = null!;
    public virtual DbSet<VfdBankOutwardTransferLog> VfdBankOutwardTransferLogs { get; set; } = null!;
    public virtual DbSet<VfdBankWebHookLog> VfdBankWebHookLogs { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActLog>(entity =>
        {
            entity.HasKey(e => e.Memopointer)
                .HasName("PK__ActLog__1DB1FD6A633E2B58");

            entity.ToTable("ActLog");

            entity.HasIndex(e => e.User1, "ACTL_KEY_DATA_TRACKER");

            entity.HasIndex(e => new { e.Date, e.Time }, "ACTL_K_DATE");

            entity.HasIndex(e => new { e.Procname, e.Date, e.Time }, "ACTL_K_PROCNAME");

            entity.HasIndex(e => new { e.Recordid, e.Filename, e.Date, e.Time }, "ACTL_K_RECORDID");

            entity.HasIndex(e => new { e.Userid, e.Date, e.Time }, "ACTL_K_USERID");

            entity.Property(e => e.Memopointer)
                .ValueGeneratedNever()
                .HasColumnName("MEMOPOINTER");

            entity.Property(e => e.Computername)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("COMPUTERNAME")
                .IsFixedLength();

            entity.Property(e => e.Date).HasColumnName("DATE");

            entity.Property(e => e.Deletedfilename)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DELETEDFILENAME")
                .IsFixedLength();

            entity.Property(e => e.Delpointer).HasColumnName("DELPOINTER");

            entity.Property(e => e.Fieldname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FIELDNAME")
                .IsFixedLength();

            entity.Property(e => e.Filename)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("FILENAME")
                .IsFixedLength();

            entity.Property(e => e.Newvalue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NEWVALUE")
                .IsFixedLength();

            entity.Property(e => e.Oldvalue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OLDVALUE")
                .IsFixedLength();

            entity.Property(e => e.Primafield)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PRIMAFIELD")
                .IsFixedLength();

            entity.Property(e => e.Procname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PROCNAME")
                .IsFixedLength();

            entity.Property(e => e.Recordid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RECORDID")
                .IsFixedLength();

            entity.Property(e => e.Recordid2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RECORDID2")
                .IsFixedLength();

            entity.Property(e => e.Time).HasColumnName("TIME");

            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TYPE")
                .IsFixedLength();

            entity.Property(e => e.User1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USER1")
                .IsFixedLength();

            entity.Property(e => e.User2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USER2")
                .IsFixedLength();

            entity.Property(e => e.User3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USER3")
                .IsFixedLength();

            entity.Property(e => e.User4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USER4")
                .IsFixedLength();

            entity.Property(e => e.Userid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USERID")
                .IsFixedLength();
        });

        modelBuilder.Entity<ActLogM>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("ActLogM");

            entity.HasIndex(e => e.Memopointer, "ACTM_K_MEMOPOINTER");

            entity.Property(e => e.Memopointer).HasColumnName("MEMOPOINTER");

            entity.Property(e => e.Newmemo)
                .HasMaxLength(3999)
                .IsUnicode(false)
                .HasColumnName("NEWMEMO");

            entity.Property(e => e.Oldmemo)
                .HasMaxLength(3999)
                .IsUnicode(false)
                .HasColumnName("OLDMEMO");
        });

        modelBuilder.Entity<AppBranch>(entity =>
        {
            entity.HasKey(e => e.IdBranches);

            entity.ToTable("AppBranch");

            entity.Property(e => e.IdBranches)
                .HasColumnName("ID_Branches")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.BranchCode)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.Property(e => e.BranchName).HasMaxLength(150);

            entity.Property(e => e.DatabaseName).HasMaxLength(150);

            entity.Property(e => e.DbPassword).HasMaxLength(50);

            entity.Property(e => e.DbUsername).HasMaxLength(50);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(5)
                .HasColumnName("ID_Application");

            entity.Property(e => e.MoneyBookDatabase).HasMaxLength(150);

            entity.Property(e => e.ServerName).HasMaxLength(150);
        });

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.IdUser)
                .HasName("PK_Users");

            entity.ToTable("ApplicationUser");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FirstName).HasMaxLength(50);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.LastDeactivatedDate).HasColumnType("datetime");

            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.Property(e => e.LastPasswordResetDate).HasColumnType("datetime");

            entity.Property(e => e.LastReactivatedDate).HasColumnType("datetime");

            entity.Property(e => e.NextPasswordChangeDate).HasColumnType("datetime");

            entity.Property(e => e.Password).HasMaxLength(3000);

            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<AuditTrail>(entity =>
        {
            entity.HasKey(e => e.IdLogTrail);

            entity.ToTable("AuditTrail");

            entity.Property(e => e.IdLogTrail).HasColumnName("ID_LogTrail");

            entity.Property(e => e.ActionDate).HasColumnType("datetime");

            entity.Property(e => e.ApplicationUser).HasMaxLength(50);

            entity.Property(e => e.FormName).HasMaxLength(150);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(5)
                .HasColumnName("ID_Application")
                .IsFixedLength();

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(256)
                .HasColumnName("IPAddress");

            entity.Property(e => e.Url).HasMaxLength(150);
        });

        modelBuilder.Entity<CorporateActionDetail>(entity =>
        {
            entity.HasKey(e => e.IdCorporateActionDetail);

            entity.ToTable("CorporateActionDetail");

            entity.Property(e => e.IdCorporateActionDetail).HasColumnName("ID_CorporateActionDetail");

            entity.Property(e => e.ClosureDate).HasColumnType("datetime");

            entity.Property(e => e.DeclaredId).HasColumnName("DeclaredID");

            entity.Property(e => e.DividendRate).HasColumnType("decimal(18, 8)");

            entity.Property(e => e.DividendType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.IdCorporateActionMaster).HasColumnName("ID_CorporateActionMaster");

            entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            entity.Property(e => e.ShareId).HasColumnName("ShareID");

            entity.HasOne(d => d.IdCorporateActionMasterNavigation)
                .WithMany(p => p.CorporateActionDetails)
                .HasForeignKey(d => d.IdCorporateActionMaster)
                .HasConstraintName("FK_CorporateActionDetail_CorporateActionMaster");
        });

        modelBuilder.Entity<CorporateActionMaster>(entity =>
        {
            entity.HasKey(e => e.IdCorporateActionMaster);

            entity.ToTable("CorporateActionMaster");

            entity.HasIndex(e => new { e.Symbol, e.FinYear }, "Key_CorporateActionMaster_SymbolYear")
                .IsUnique();

            entity.Property(e => e.IdCorporateActionMaster).HasColumnName("ID_CorporateActionMaster");

            entity.Property(e => e.AnnualId).HasColumnName("AnnualID");

            entity.Property(e => e.BonusClosureDate).HasColumnType("datetime");

            entity.Property(e => e.BonusFor)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.BonusRate)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.FinYear)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.Property(e => e.PeRatio)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("PE_Ratio");

            entity.Property(e => e.ProfitAfterTax).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ProfitAfterTaxQ1).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ProfitAfterTaxQ2).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ProfitAfterTaxQ3).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Rating)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.ShareId).HasColumnName("ShareID");

            entity.Property(e => e.ShareInIssue).HasColumnType("decimal(28, 4)");

            entity.Property(e => e.Symbol)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.TurnOverQ1).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.TurnOverQ2).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.TurnOverQ3).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CurrencyAccountMapping>(entity =>
        {
            entity.HasKey(e => e.IdCurrencyAccountMapping);

            entity.ToTable("CurrencyAccountMapping");

            entity.Property(e => e.IdCurrencyAccountMapping).HasColumnName("ID_CurrencyAccountMapping");

            entity.Property(e => e.IdBankAccount)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_BankAccount");

            entity.Property(e => e.IdCashMgtAccountLogement)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_CashMgtAccountLogement");

            entity.Property(e => e.IdCashMgtAccountWithdrawal)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_CashMgtAccountWithdrawal");

            entity.Property(e => e.IdCurrency)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_Currency");
        });

        modelBuilder.Entity<CustomerRiskProfile>(entity =>
        {
            entity.HasKey(e => e.IdCustomerRiskProfile);

            entity.ToTable("CustomerRiskProfile");

            entity.HasIndex(e => e.Ucid, "Key_CustomerRiskProfile_UCID");

            entity.Property(e => e.IdCustomerRiskProfile).HasColumnName("ID_CustomerRiskProfile");

            entity.Property(e => e.AssessesBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CapturedBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CapturedDate).HasColumnType("datetime");

            entity.Property(e => e.ProcessDate).HasColumnType("datetime");

            entity.Property(e => e.Referee)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RiskClass)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.CustomerRiskProfiles)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_CustomerRiskProfile_IbsPeople");
        });

        modelBuilder.Entity<CustomerRiskProfileDetail>(entity =>
        {
            entity.HasKey(e => e.IdCustomerRiskProfileDetail);

            entity.ToTable("CustomerRiskProfileDetail");

            entity.HasIndex(e => e.IdCustomerRiskProfile, "Key_CustomerRiskProfileDetail_RiskProfileID");

            entity.Property(e => e.IdCustomerRiskProfileDetail).HasColumnName("ID_CustomerRiskProfileDetail");

            entity.Property(e => e.IdCustomerRiskProfile).HasColumnName("ID_CustomerRiskProfile");

            entity.Property(e => e.IdRiskCheck).HasColumnName("ID_RiskCheck");

            entity.HasOne(d => d.IdCustomerRiskProfileNavigation)
                .WithMany(p => p.CustomerRiskProfileDetails)
                .HasForeignKey(d => d.IdCustomerRiskProfile)
                .HasConstraintName("FK_CustomerRiskProfileDetail_CustomerRiskProfile");

            entity.HasOne(d => d.IdRiskCheckNavigation)
                .WithMany(p => p.CustomerRiskProfileDetails)
                .HasForeignKey(d => d.IdRiskCheck)
                .HasConstraintName("FK_CustomerRiskProfileDetail_RiskChekList");
        });

        modelBuilder.Entity<EconomicSector>(entity =>
        {
            entity.HasKey(e => e.IdEconomicSector);

            entity.ToTable("EconomicSector");

            entity.HasIndex(e => e.EconomicSector1, "Key_EconomicSector_EconomicSector")
                .IsUnique();

            entity.Property(e => e.IdEconomicSector).HasColumnName("ID_EconomicSector");

            entity.Property(e => e.EconomicSector1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EconomicSector");
        });

        modelBuilder.Entity<GsmValidator>(entity =>
        {
            entity.HasKey(e => e.IdGsmFormat);

            entity.ToTable("GsmValidator");

            entity.Property(e => e.IdGsmFormat).HasColumnName("ID_GsmFormat");

            entity.Property(e => e.Gsm1st3Digits)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.ProviderCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IReport4MoneyBook>(entity =>
        {
            entity.HasKey(e => e.Reportid)
                .HasName("PK_iReports4MoneyBook");

            entity.ToTable("iReport4MoneyBook");

            entity.HasIndex(e => e.Narration, "IRPT_KEY_IREPORT_REPNAME");

            entity.HasIndex(e => e.IdReportgroup, "Key_iReports_ReportGroup");

            entity.Property(e => e.Reportid).HasColumnName("REPORTID");

            entity.Property(e => e.IdReportgroup).HasColumnName("ID_REPORTGROUP");

            entity.Property(e => e.Narration)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NARRATION")
                .IsFixedLength();

            entity.Property(e => e.Reportfilename)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("REPORTFILENAME");

            entity.Property(e => e.Runbefore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RUNBEFORE");

            entity.Property(e => e.Sensitivitylevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SENSITIVITYLEVEL")
                .IsFixedLength();

            entity.Property(e => e.Show4All).HasColumnName("SHOW_4_ALL");

            entity.Property(e => e.Show4CashBook).HasColumnName("SHOW_4_CashBook");

            entity.Property(e => e.Show4Gledger).HasColumnName("SHOW_4_GLedger");

            entity.Property(e => e.Show4Recon).HasColumnName("SHOW_4_Recon");
        });

        modelBuilder.Entity<IReport4MoneyBookParameter>(entity =>
        {
            entity.HasKey(e => e.IdReportParameter)
                .HasName("PK_iReports4MoneyBookParameters");

            entity.ToTable("iReport4MoneyBookParameters");

            entity.HasIndex(e => new { e.ReportId, e.ParaName }, "Key_iReportsParameters_Unique")
                .IsUnique();

            entity.Property(e => e.IdReportParameter).HasColumnName("ID_ReportParameter");

            entity.Property(e => e.DefaultValue)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ParaDesc)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ParaName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ReportId).HasColumnName("ReportID");

            entity.HasOne(d => d.Report)
                .WithMany(p => p.IReport4MoneyBookParameters)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_iReports4MoneyBookParameters_iReports");
        });

        modelBuilder.Entity<IReport4Moneytor>(entity =>
        {
            entity.HasKey(e => e.Reportid)
                .HasName("PK__iReports__A85DEB2D266119A1");

            entity.ToTable("iReport4Moneytor");

            entity.Property(e => e.Reportid).HasColumnName("REPORTID");

            entity.Property(e => e.IbsParameter)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_APPLICATION");

            entity.Property(e => e.IdReportgroup).HasColumnName("ID_REPORTGROUP");

            entity.Property(e => e.Narration)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NARRATION")
                .IsFixedLength();

            entity.Property(e => e.ReportParameter)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Reportfilename)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("REPORTFILENAME");

            entity.Property(e => e.Runbefore)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("RUNBEFORE");

            entity.Property(e => e.Sensitivitylevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SENSITIVITYLEVEL")
                .IsFixedLength();

            entity.Property(e => e.Show4All).HasColumnName("SHOW_4_ALL");

            entity.Property(e => e.Show4Contributor).HasColumnName("SHOW_4_CONTRIBUTOR");

            entity.Property(e => e.Show4Portfolio).HasColumnName("SHOW_4_PORTFOLIO");

            entity.Property(e => e.Show4Portfoliogroup).HasColumnName("SHOW_4_PORTFOLIOGROUP");
        });

        modelBuilder.Entity<IReport4MoneytorParameter>(entity =>
        {
            entity.HasKey(e => e.IdReportParameter)
                .HasName("PK_iReportsParameters");

            entity.ToTable("iReport4MoneytorParameters");

            entity.Property(e => e.IdReportParameter).HasColumnName("ID_ReportParameter");

            entity.Property(e => e.DefaultValue)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ParaDesc)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ParaName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ReportId).HasColumnName("ReportID");

            entity.HasOne(d => d.Report)
                .WithMany(p => p.IReport4MoneytorParameters)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_iReportsParameters_iReports");
        });

        modelBuilder.Entity<IReportGroup4MoneyBook>(entity =>
        {
            entity.HasKey(e => e.IdReportGroup);

            entity.ToTable("iReportGroup4MoneyBook");

            entity.HasIndex(e => e.Reportgroupname, "UQ_iReportGroup4MoneyBook")
                .IsUnique();

            entity.Property(e => e.IdReportGroup)
                .ValueGeneratedNever()
                .HasColumnName("ID_ReportGroup");

            entity.Property(e => e.Dataselector)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DATASELECTOR")
                .IsFixedLength();

            entity.Property(e => e.Reportgroupname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("REPORTGROUPNAME");
        });

        modelBuilder.Entity<IReportGroup4Moneytor>(entity =>
        {
            entity.HasKey(e => e.IdReportGroup)
                .HasName("PK__iReportG__B3C0BC8D085C0180");

            entity.ToTable("iReportGroup4Moneytor");

            entity.HasIndex(e => e.Reportgroupname, "UQ__iReportG__22EABCF07BEAD537")
                .IsUnique();

            entity.Property(e => e.IdReportGroup).HasColumnName("ID_ReportGroup");

            entity.Property(e => e.Dataselector)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DATASELECTOR")
                .IsFixedLength();

            entity.Property(e => e.Reportgroupname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("REPORTGROUPNAME");
        });

        modelBuilder.Entity<IbsAccountStatementRequest>(entity =>
        {
            entity.HasKey(e => e.IdAccountStatementRequest);

            entity.ToTable("IbsAccountStatementRequest");

            entity.Property(e => e.IdAccountStatementRequest).HasColumnName("ID_AccountStatementRequest");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.BeginDate).HasColumnType("datetime");

            entity.Property(e => e.CaptureDate).HasColumnType("datetime");

            entity.Property(e => e.Capturedby)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Comments).HasColumnType("text");

            entity.Property(e => e.Dbid).HasColumnName("DBID");

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.IdPortfolioContributor).HasColumnName("ID_PortfolioContributor");

            entity.Property(e => e.IdStatementType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_StatementType")
                .IsFixedLength();

            entity.Property(e => e.IdToPrint)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ID_To_Print");

            entity.Property(e => e.PdfFileName)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.Printdate).HasColumnType("datetime");

            entity.Property(e => e.Printedby)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RequestDate).HasColumnType("datetime");

            entity.Property(e => e.SentDate).HasColumnType("datetime");

            entity.Property(e => e.Sentby)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.Property(e => e.VoucherNo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsAgentMarketer>(entity =>
        {
            entity.HasKey(e => e.IdAgentMarketer);

            entity.ToTable("IbsAgentMarketer");

            entity.HasIndex(e => e.AgentCode, "Key_IbsAgentMarketer_AgentCode")
                .IsUnique();

            entity.HasIndex(e => e.AgentName, "Key_IbsAgentMarketer_AgentName");

            entity.Property(e => e.IdAgentMarketer).HasColumnName("ID_AgentMarketer");

            entity.Property(e => e.AccountNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Address01)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_01");

            entity.Property(e => e.Address02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_02");

            entity.Property(e => e.AgentCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.AgentName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.BankAccountName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.BankBranchName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ComisionRate).HasColumnType("decimal(18, 4)");

            entity.Property(e => e.Comments).HasColumnType("text");

            entity.Property(e => e.ContractDate).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.IdBank)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Bank");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.TerminalDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<IbsApplication>(entity =>
        {
            entity.HasKey(e => e.IdApplication);

            entity.ToTable("IBS_Application");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.Lic).HasColumnName("LIC");

            entity.Property(e => e.Money4LodgementActNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Money4PaymentActNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsAuditLog>(entity =>
        {
            entity.HasKey(e => e.IdIbsAuditLog);

            entity.ToTable("IbsAuditLog");

            entity.HasIndex(e => e.Changetimestamp, "Key_AuditLog_ChangeTimeStamp");

            entity.HasIndex(e => new { e.UserId, e.Changetimestamp }, "Key_AuditLog_UserID_Datetime");

            entity.Property(e => e.IdIbsAuditLog).HasColumnName("ID_IbsAuditLog");

            entity.Property(e => e.Changetimestamp).HasPrecision(3);

            entity.Property(e => e.ComputerName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Fieldname)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Filename)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.NewValue).IsUnicode(false);

            entity.Property(e => e.OldValue).IsUnicode(false);

            entity.Property(e => e.Primafield)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.ProcName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Udf01)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UDF01");

            entity.Property(e => e.Udf02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UDF02");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<IbsBank>(entity =>
        {
            entity.HasKey(e => e.IdBank);

            entity.ToTable("IBS_Banks");

            entity.HasIndex(e => e.BankCode, "Key_IBS_Bank_BankCode");

            entity.HasIndex(e => e.BankName, "Key_IBS_BanksName")
                .IsUnique();

            entity.Property(e => e.IdBank)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Bank");

            entity.Property(e => e.Address01)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.BankCode)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.Property(e => e.BankGlActNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.HqrsortCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HQRSortCode");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.SwitchCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsBankSortCode>(entity =>
        {
            entity.HasKey(e => e.IdBankSortCode);

            entity.ToTable("IBS_BankSortCode");

            entity.Property(e => e.IdBankSortCode).HasColumnName("ID_BankSortCode");

            entity.Property(e => e.BranchName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.IdBank)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Bank");

            entity.Property(e => e.SortCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBankNavigation)
                .WithMany(p => p.IbsBankSortCodes)
                .HasForeignKey(d => d.IdBank)
                .HasConstraintName("FK_IBS_BankSortCode_IBS_Banks");
        });

        modelBuilder.Entity<IbsBirthdayMessage>(entity =>
        {
            entity.HasKey(e => e.IdBirthdayMessages);

            entity.Property(e => e.IdBirthdayMessages).HasColumnName("ID_BirthdayMessages");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.IdMessageServer).HasColumnName("ID_MessageServer");

            entity.Property(e => e.MessageType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<IbsBranch>(entity =>
        {
            entity.HasKey(e => e.IdBranch);

            entity.ToTable("IBS_Branches");

            entity.HasIndex(e => e.Name, "Key_IBS_Branches_Name")
                .IsUnique();

            entity.Property(e => e.IdBranch)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Branch");

            entity.Property(e => e.AccessLevel)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsCauseOfDeath>(entity =>
        {
            entity.HasKey(e => e.CauseOfDeathId);

            entity.ToTable("IbsCauseOfDeath");

            entity.HasIndex(e => e.CauseOfDeathId, "Key_IbsCauseOfDeath_CauseOfDeath")
                .IsUnique();

            entity.Property(e => e.CauseOfDeathId).HasColumnName("CauseOfDeathID");

            entity.Property(e => e.CauseOfDeath)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsClientType>(entity =>
        {
            entity.HasKey(e => e.IdClientType);

            entity.ToTable("IbsClientType");

            entity.Property(e => e.IdClientType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_ClientType");

            entity.Property(e => e.CustomerType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsCountry>(entity =>
        {
            entity.HasKey(e => e.IdCountry);

            entity.ToTable("IBS_Country");

            entity.HasIndex(e => e.Country, "Key_IBS_Country_Country")
                .IsUnique();

            entity.Property(e => e.IdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Country");

            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsCurrency>(entity =>
        {
            entity.HasKey(e => e.IdCurrency);

            entity.ToTable("IBS_Currency");

            entity.HasIndex(e => e.Currency, "Key_Currency_Currency")
                .IsUnique();

            entity.Property(e => e.IdCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Currency");

            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsEmployer>(entity =>
        {
            entity.HasKey(e => e.EmployerCode);

            entity.ToTable("Ibs_Employer");

            entity.Property(e => e.EmployerCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.BusinesName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.EmpId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmpID");

            entity.Property(e => e.RcNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsExcRate>(entity =>
        {
            entity.HasKey(e => e.ExcRateId)
                .HasName("PK_ExcRate");

            entity.ToTable("IBS_ExcRate");

            entity.Property(e => e.ExcRateId).HasColumnName("ExcRate_ID");

            entity.Property(e => e.CurrencyId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CurrencyID");

            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

            entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.IbsExcRates)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_IBS_ExcRate_IBS_Currency");
        });

        modelBuilder.Entity<IbsHospital>(entity =>
        {
            entity.HasKey(e => e.IdHospital)
                .HasName("PK_Hospital");

            entity.ToTable("IBS_Hospital");

            entity.Property(e => e.IdHospital).HasColumnName("ID_Hospital");

            entity.Property(e => e.Address01)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ContactPerson)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Hospital)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Telephones)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<IbsIncomeRange>(entity =>
        {
            entity.HasKey(e => e.IdIncomeRange);

            entity.ToTable("Ibs_IncomeRange");

            entity.Property(e => e.IdIncomeRange).HasColumnName("ID_IncomeRange");

            entity.Property(e => e.BeginAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("beginAmount");

            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.EndAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("endAmount");
        });

        modelBuilder.Entity<IbsLgarea>(entity =>
        {
            entity.HasKey(e => e.IdLga);

            entity.ToTable("IBS_LGArea");

            entity.HasIndex(e => e.LgArea, "Key_LGArea_Lg_Area");

            entity.Property(e => e.IdLga)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_LGA");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.LgArea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LG_Area");

            entity.HasOne(d => d.IdStateNavigation)
                .WithMany(p => p.IbsLgareas)
                .HasForeignKey(d => d.IdState)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IBSLGArea_States");
        });

        modelBuilder.Entity<IbsNotification>(entity =>
        {
            entity.HasKey(e => e.IdNotifications);

            entity.HasIndex(e => new { e.IdApplication, e.NotificationType, e.IdNotifyClass }, "key_IbsNotifications_Unique")
                .IsUnique();

            entity.Property(e => e.IdNotifications).HasColumnName("ID_Notifications");

            entity.Property(e => e.HtmlMessage).HasColumnType("text");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdNotifyClass)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_NotifyClass");

            entity.Property(e => e.MailSubject)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsNotifyClass>(entity =>
        {
            entity.HasKey(e => e.IdNotifyClass);

            entity.ToTable("IbsNotifyClass");

            entity.HasIndex(e => e.NotifyClass, "Key_IbsNotifyClass_NotifyClass")
                .IsUnique();

            entity.Property(e => e.IdNotifyClass)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_NotifyClass");

            entity.Property(e => e.NotifyClass)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsOccupation>(entity =>
        {
            entity.HasKey(e => e.IdOccupation);

            entity.ToTable("IBS_Occupation");

            entity.HasIndex(e => e.Occupation, "Key_IBS_Occupation_Occupation")
                .IsUnique();

            entity.Property(e => e.IdOccupation).HasColumnName("ID_Occupation");

            entity.Property(e => e.Occupation)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.OccupationCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsPaymentChannelBankAccount>(entity =>
        {
            entity.HasKey(e => e.IdIbsPaymentChannelBankAccount);

            entity.ToTable("Ibs_PaymentChannelBankAccount");

            entity.Property(e => e.IdIbsPaymentChannelBankAccount).HasColumnName("Id_Ibs_PaymentChannelBankAccount");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Id_Application");

            entity.Property(e => e.IdBankAccount)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_BankAccount");

            entity.Property(e => e.NibssBillerAccountCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NIBSS_Biller_AccountCode");

            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsPeopleAccountSignatory>(entity =>
        {
            entity.HasKey(e => e.IdAccountSignatory);

            entity.ToTable("IbsPeopleAccountSignatory");

            entity.HasIndex(e => e.Ucid, "Key_IbsPeopleAccountSignatory_UCID");

            entity.Property(e => e.IdAccountSignatory).HasColumnName("ID_AccountSignatory");

            entity.Property(e => e.Address01)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Bvn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BVN");

            entity.Property(e => e.Bvnverified).HasColumnName("BVNVerified");

            entity.Property(e => e.CaptureDate).HasColumnType("datetime");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.IdIdentifyWith)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_IdentifyWith");

            entity.Property(e => e.IdLga)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_LGA");

            entity.Property(e => e.IdOccupation).HasColumnName("ID_Occupation");

            entity.Property(e => e.IdPlaceOfBirth).HasColumnName("ID_PlaceOfBirth");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.IdStateOfOrigin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_StateOfOrigin");

            entity.Property(e => e.Idnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDNumber");

            entity.Property(e => e.IssueDate).HasColumnType("datetime");

            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.MobilePhone01)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.MobilePhone02)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.MotherMaidenName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Nationalty)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.OtherCountryOfTaxResidence)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.OtherName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PermitExpiryDate).HasColumnType("datetime");

            entity.Property(e => e.PermitIssueDate).HasColumnType("datetime");

            entity.Property(e => e.ResidensyStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.ResidentPermit)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.SignatoryClass)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.SignatureScan).HasColumnType("image");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleAccountSignatories)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleAccountSignatory_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleAssociationMember>(entity =>
        {
            entity.HasKey(e => e.IdAssociationMember);

            entity.ToTable("IbsPeopleAssociationMember");

            entity.Property(e => e.IdAssociationMember).HasColumnName("ID_AssociationMember");

            entity.Property(e => e.BankAccountNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Bvn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BVN");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.OtherNames)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleAssociationMembers)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleAssociationMember_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleBankAccount>(entity =>
        {
            entity.HasKey(e => e.IdBankAccount);

            entity.ToTable("IbsPeopleBankAccount");

            entity.HasIndex(e => e.IdBank, "Key_IbsPeopleBankAccount_BankID");

            entity.HasIndex(e => e.Ucid, "Key_IbsPeopleBankAccount_UCID");

            entity.Property(e => e.IdBankAccount).HasColumnName("ID_BankAccount");

            entity.Property(e => e.AccountName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Bvn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BVN");

            entity.Property(e => e.IdBank)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Bank");

            entity.Property(e => e.SortCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleBankAccounts)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleBankAccount_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleContactPerson>(entity =>
        {
            entity.HasKey(e => e.IdContactPerson);

            entity.ToTable("IbsPeopleContactPerson");

            entity.HasIndex(e => e.Ucid, "Key_IbsPeopleContactPerson_UCID");

            entity.Property(e => e.IdContactPerson).HasColumnName("ID_ContactPerson");

            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNo)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleContactPeople)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleContactPerson_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleDirector>(entity =>
        {
            entity.HasKey(e => e.IdDirector);

            entity.ToTable("IbsPeopleDirector");

            entity.HasIndex(e => e.IdDirector, "Key_IbsPeopleDirector_UCID");

            entity.Property(e => e.IdDirector).HasColumnName("ID_Director");

            entity.Property(e => e.Bvn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BVN");

            entity.Property(e => e.Bvnverified).HasColumnName("BVNVerified");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.HoldingPercent).HasColumnType("decimal(18, 4)");

            entity.Property(e => e.IdIdentifyWith)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_IdentifyWith");

            entity.Property(e => e.Idnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDNumber");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Nationalty)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.OtherNames)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleDirectors)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleDirector_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleEmployer>(entity =>
        {
            entity.HasKey(e => e.IdEmployer);

            entity.ToTable("IbsPeopleEmployer");

            entity.Property(e => e.IdEmployer).HasColumnName("ID_Employer");

            entity.Property(e => e.Address01)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DateEmployed).HasColumnType("datetime");

            entity.Property(e => e.EmployerCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.EmploymentType)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.IdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Country");

            entity.Property(e => e.IdOccupation).HasColumnName("ID_Occupation");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.Property(e => e.Website)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.EmployerCodeNavigation)
                .WithMany(p => p.IbsPeopleEmployers)
                .HasForeignKey(d => d.EmployerCode)
                .HasConstraintName("FK_IbsPeopleEmployer_Ibs_Employer");
        });

        modelBuilder.Entity<IbsPeopleJointMember>(entity =>
        {
            entity.HasKey(e => e.IdJointMember);

            entity.ToTable("IbsPeopleJointMember");

            entity.Property(e => e.IdJointMember).HasColumnName("ID_JointMember");

            entity.Property(e => e.Address01)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Bvn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BVN");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.EmployerAddress)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.EmployerCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.EmploymentType)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.IdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Country");

            entity.Property(e => e.IdIdentifyWith)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_IdentifyWith");

            entity.Property(e => e.IdIdplaceOfIssue).HasColumnName("ID_IDPlaceOfIssue");

            entity.Property(e => e.IdOccupation).HasColumnName("ID_Occupation");

            entity.Property(e => e.IdReligion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_Religion");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.IdStateOfOrigin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_StateOfOrigin");

            entity.Property(e => e.IdentifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.IdexpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("IDExpiryDate");

            entity.Property(e => e.IdissueDate)
                .HasColumnType("datetime")
                .HasColumnName("IDIssueDate");

            entity.Property(e => e.Idnumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNumber");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.MotherMaidenName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Nationality)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.OtherNames)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PostalAddress)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PostalAddress02)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PostalCity)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PostalIdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PostalID_Country");

            entity.Property(e => e.PostalIdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PostalID_State");

            entity.Property(e => e.ResidentPermitNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleJointMembers)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleJointMember_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleLien>(entity =>
        {
            entity.HasKey(e => e.IdIbsPeopleLien);

            entity.ToTable("IbsPeopleLien");

            entity.Property(e => e.IdIbsPeopleLien).HasColumnName("ID_IbsPeopleLien");

            entity.Property(e => e.CaptureBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CaptureDate).HasColumnType("datetime");

            entity.Property(e => e.LienDate).HasColumnType("datetime");

            entity.Property(e => e.Narration)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

            entity.Property(e => e.ReleasedBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleLiens)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleLien_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleNextOfKin>(entity =>
        {
            entity.HasKey(e => e.IdNextOfKin);

            entity.ToTable("IbsPeopleNextOfKin");

            entity.HasIndex(e => e.Ucid, "Key_IbsPeopleNextOfKin_UCID");

            entity.Property(e => e.IdNextOfKin).HasColumnName("ID_NextOfKin");

            entity.Property(e => e.Address01)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.IdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Country");

            entity.Property(e => e.IdRelationShip).HasColumnName("ID_RelationShip");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.OtherNames)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleNextOfKins)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleNextOfKin_IbsPeople");
        });

        modelBuilder.Entity<IbsPeopleRiskProfile>(entity =>
        {
            entity.HasKey(e => e.IdIbsPeopleRiskProfile);

            entity.ToTable("IbsPeopleRiskProfile");

            entity.Property(e => e.IdIbsPeopleRiskProfile).HasColumnName("ID_IbsPeopleRiskProfile");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

            entity.Property(e => e.IdKycRiskProfile)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ID_KycRiskProfile")
                .IsFixedLength();

            entity.Property(e => e.ProfileBasis)
                .HasMaxLength(2048)
                .IsUnicode(false);

            entity.Property(e => e.ProfileDate).HasColumnType("datetime");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.HasOne(d => d.Uc)
                .WithMany(p => p.IbsPeopleRiskProfiles)
                .HasForeignKey(d => d.Ucid)
                .HasConstraintName("FK_IbsPeopleRiskProfile_IbsPeople");
        });

        modelBuilder.Entity<IbsPerson>(entity =>
        {
            entity.HasKey(e => e.Ucid)
                .HasName("PK_People");

            entity.HasIndex(e => e.IdCustomerType, "Key_IbsPeople_ID_CustomerType");

            entity.HasIndex(e => e.InHouseNo, "Key_IbsPeople_InHouse");

            entity.HasIndex(e => e.Status, "Key_IbsPeople_Status");

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.Property(e => e.Address01)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.AniversaryDate).HasColumnType("datetime");

            entity.Property(e => e.Bvn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BVN");

            entity.Property(e => e.Bvnverified).HasColumnName("BVNVerified");

            entity.Property(e => e.CapturedViaBvn).HasColumnName("CapturedViaBVN");

            entity.Property(e => e.ChildDob)
                .HasColumnType("datetime")
                .HasColumnName("ChildDOB");

            entity.Property(e => e.ChildFirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ChildGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.ChildIdRelationShip).HasColumnName("ChildID_RelationShip");

            entity.Property(e => e.ChildLastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ChildOtherName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ChildTitle)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Chnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CHNumber");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Comments).HasColumnType("text");

            entity.Property(e => e.CoporateType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Cscsno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CSCSNo");

            entity.Property(e => e.DatabaseName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DateBizCommenced).HasColumnType("datetime");

            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.EmployerAddress)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.EmployerCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.EmploymentType)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.FaceBook)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.HearedFrom)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.IdAgent).HasColumnName("ID_Agent");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Country");

            entity.Property(e => e.IdCustomerType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_CustomerType")
                .HasComment("Individual (IND)\r\nMinor (MIN)\r\nCorporate (CRP)\r\nJoint (JNT)\r\nAssociation (ASS)");

            entity.Property(e => e.IdEconomicSector).HasColumnName("ID_EconomicSector");

            entity.Property(e => e.IdIdentifyWith)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_IdentifyWith");

            entity.Property(e => e.IdIdplaceOfIssue).HasColumnName("ID_IDPlaceOfIssue");

            entity.Property(e => e.IdIncomeRange).HasColumnName("ID_IncomeRange");

            entity.Property(e => e.IdNatureOfBusiness).HasColumnName("ID_NatureOfBusiness");

            entity.Property(e => e.IdOccupation).HasColumnName("ID_Occupation");

            entity.Property(e => e.IdOriginLga)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Origin_LGA");

            entity.Property(e => e.IdPlaceOfBirth).HasColumnName("ID_PlaceOfBirth");

            entity.Property(e => e.IdPostalCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_PostalCountry");

            entity.Property(e => e.IdPostalLga)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_PostalLGA");

            entity.Property(e => e.IdPostalState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_PostalState");

            entity.Property(e => e.IdReligion).HasColumnName("ID_Religion");

            entity.Property(e => e.IdResLga)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_ResLGA");

            entity.Property(e => e.IdRiskProfile)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ID_RiskProfile")
                .IsFixedLength();

            entity.Property(e => e.IdSourceOfFunds)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_SourceOfFunds");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.IdStateOfOrigin)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_StateOfOrigin");

            entity.Property(e => e.IdentifiedBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.IdexpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("IDExpiryDate");

            entity.Property(e => e.IdissueDate)
                .HasColumnType("datetime")
                .HasColumnName("IDIssueDate");

            entity.Property(e => e.Idnumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDNumber");

            entity.Property(e => e.InHouseNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Instagram)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.JointAccountName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.KycComplete).HasColumnName("Kyc_Complete");

            entity.Property(e => e.KycVerifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Kyc_VerifiedDate");

            entity.Property(e => e.KycVerifiedby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Kyc_Verifiedby");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.LinkedIn)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.MaidenName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.MotherMaidenName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Nationality)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Nim)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIM");

            entity.Property(e => e.OtherNames)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.OtherPhones)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ParrentUCID).HasColumnName("ParrentUCID");

            entity.Property(e => e.PccNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PostalAddress1)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PostalAddress2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PostalCity)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Rcnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RCNumber");

            entity.Property(e => e.ResidentPermit)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RiskClass)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.ScumlregNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SCUMLRegNo");

            entity.Property(e => e.Smsnotification).HasColumnName("SMSNotification");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Tin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TIN");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Twiter)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Vatno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VATNo");

            entity.Property(e => e.WebSite)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsPfa>(entity =>
        {
            entity.HasKey(e => e.IdPfa);

            entity.ToTable("IBS_PFA");

            entity.HasIndex(e => e.PfaName, "Key_IBS_PFA_PFA_Name")
                .IsUnique();

            entity.Property(e => e.IdPfa)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_PFA");

            entity.Property(e => e.Address01)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Address02)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.GsmPhone1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GSM_Phone1");

            entity.Property(e => e.GsmPhone2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GSM_Phone2");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.PfaName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PFA_Name");

            entity.Property(e => e.WebSite)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsPlaceOfBirth>(entity =>
        {
            entity.HasKey(e => e.IdIbsPob);

            entity.ToTable("Ibs_PlaceOfBirth");

            entity.Property(e => e.IdIbsPob).HasColumnName("ID_IbsPOB");

            entity.Property(e => e.IdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Country");

            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsPostCode>(entity =>
        {
            entity.HasKey(e => e.PostCode);

            entity.ToTable("IBS_PostCode");

            entity.HasIndex(e => e.Name, "Key_IBS_PostCode_Name")
                .IsUnique();

            entity.Property(e => e.PostCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsProductLine>(entity =>
        {
            entity.HasKey(e => e.IdProductLine);

            entity.ToTable("IBS_ProductLine");

            entity.HasIndex(e => e.ProductLine, "Key_IBS_ProductLine")
                .IsUnique();

            entity.Property(e => e.IdProductLine)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_ProductLine");

            entity.Property(e => e.ProductLine)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsRegion>(entity =>
        {
            entity.HasKey(e => e.IdRegion)
                .HasName("PK_AgencyRegion");

            entity.ToTable("Ibs_Region");

            entity.Property(e => e.IdRegion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Region");

            entity.Property(e => e.RegionName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsReligion>(entity =>
        {
            entity.HasKey(e => e.IdReligion);

            entity.ToTable("Ibs_Religion");

            entity.HasIndex(e => e.Religion, "Key_Ibs_Religion_Religion")
                .IsUnique();

            entity.Property(e => e.IdReligion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Religion");

            entity.Property(e => e.Religion)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsState>(entity =>
        {
            entity.HasKey(e => e.IdState);

            entity.ToTable("IBS_States");

            entity.Property(e => e.IdState)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_State");

            entity.Property(e => e.IdCountry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Country");

            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsStatementType>(entity =>
        {
            entity.HasKey(e => e.IdStatementType);

            entity.Property(e => e.IdStatementType)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_StatementType")
                .IsFixedLength();

            entity.Property(e => e.CrystalReportFileName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Fees).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");

            entity.Property(e => e.StatementType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IbsTitle>(entity =>
        {
            entity.HasKey(e => e.Title);

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<IbsTransactionClass>(entity =>
        {
            entity.HasKey(e => e.IdTransClass)
                .HasName("PK_TransactionClass");

            entity.ToTable("IbsTransactionClass");

            entity.HasIndex(e => e.TransClass, "Key_TransactionClass_TransClass")
                .IsUnique();

            entity.Property(e => e.IdTransClass)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ID_TransClass")
                .IsFixedLength();

            entity.Property(e => e.TransClass)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<IdentifyPeopleWith>(entity =>
        {
            entity.HasKey(e => e.IdIdentifyWith);

            entity.ToTable("IdentifyPeopleWith");

            entity.HasIndex(e => e.IdentifyWith, "IdentifyPeopleWith_IdentifyWith")
                .IsUnique();

            entity.Property(e => e.IdIdentifyWith)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ID_IdentifyWith");

            entity.Property(e => e.IdentifyWith)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InterfaceManager>(entity =>
        {
            entity.HasKey(e => e.IdIManager);

            entity.ToTable("InterfaceManager");

            entity.HasIndex(e => e.IdApplication, "Key_InterfaceManager_ID_Application");

            entity.Property(e => e.IdIManager)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ID_iManager");

            entity.Property(e => e.DbName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.PrimaryFieldName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ReceiptSpName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Receipt_sp_Name");

            entity.Property(e => e.RequisitionSpName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Requisition_sp_Name");

            entity.Property(e => e.ReversalSpName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Reversal_sp_Name");

            entity.Property(e => e.TblName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.VoucherFieldName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KycRiskProfile>(entity =>
        {
            entity.HasKey(e => e.IdKycRiskProfile);

            entity.ToTable("KycRiskProfile");

            entity.HasIndex(e => e.RiskProfile, "IX_KycRiskProfile_RiskProfile")
                .IsUnique();

            entity.Property(e => e.IdKycRiskProfile)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ID_KycRiskProfile")
                .IsFixedLength();

            entity.Property(e => e.MaxBalance).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.MaxDeposit).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.MaxRedemption).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.MinDeposit).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.RiskProfile)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.IdLocation);

            entity.ToTable("Location");

            entity.HasIndex(e => e.Location1, "Key_Location_Location")
                .IsUnique();

            entity.Property(e => e.IdLocation)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Location");

            entity.Property(e => e.Location1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Location");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu);

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu)
                .HasColumnName("ID_Menu")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Action).HasMaxLength(150);

            entity.Property(e => e.Area).HasMaxLength(150);

            entity.Property(e => e.Controller).HasMaxLength(150);

            entity.Property(e => e.DataRoute).HasMaxLength(50);

            entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((1))");

            entity.Property(e => e.Icon).HasMaxLength(50);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.MenuText).HasMaxLength(50);
        });

        modelBuilder.Entity<MessageServer>(entity =>
        {
            entity.HasKey(e => e.IdMessageServer);

            entity.ToTable("MessageServer");

            entity.HasIndex(e => e.EMailStatus, "Key_MessageServer_EmailStatus");

            entity.HasIndex(e => e.IdApplication, "Key_MessageServer_ID_Application");

            entity.HasIndex(e => e.SmsStatus, "Key_MessageServer_SmsStatus");

            entity.Property(e => e.IdMessageServer).HasColumnName("ID_MessageServer");

            entity.Property(e => e.Comments).HasColumnType("text");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.EMailIsHtml).HasColumnName("eMailIsHtml");

            entity.Property(e => e.EMailMessage)
                .HasColumnType("text")
                .HasColumnName("eMailMessage");

            entity.Property(e => e.EMailStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("eMailStatus")
                .IsFixedLength();

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("emailAddress");

            entity.Property(e => e.EmailAttachment)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("emailAttachment");

            entity.Property(e => e.EmailResponse)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("emailResponse");

            entity.Property(e => e.EmailSentDate)
                .HasColumnType("datetime")
                .HasColumnName("emailSentDate");

            entity.Property(e => e.EmailSubject)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("emailSubject");

            entity.Property(e => e.EmailccAddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("emailccAddress");

            entity.Property(e => e.FromEmailAddress)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fromEmailAddress");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.SenderDisplayName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("senderDisplayName");

            entity.Property(e => e.SmsGsmNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("smsGsmNo");

            entity.Property(e => e.SmsMessage)
                .HasColumnType("text")
                .HasColumnName("smsMessage");

            entity.Property(e => e.SmsResponse)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("smsResponse");

            entity.Property(e => e.SmsSentDate)
                .HasColumnType("datetime")
                .HasColumnName("smsSentDate");

            entity.Property(e => e.SmsStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("smsStatus")
                .IsFixedLength();

            entity.HasOne(d => d.IdApplicationNavigation)
                .WithMany(p => p.MessageServers)
                .HasForeignKey(d => d.IdApplication)
                .HasConstraintName("FK_MessageServer_IBS_Application");
        });

        modelBuilder.Entity<NatureOfbusiness>(entity =>
        {
            entity.HasKey(e => e.IdNatureOfbusiness);

            entity.ToTable("NatureOfbusiness");

            entity.HasIndex(e => e.IdNatureOfbusiness, "Key_NatureOfbusiness_NatureOfbusiness")
                .IsUnique();

            entity.Property(e => e.IdNatureOfbusiness).HasColumnName("ID_NatureOfbusiness");

            entity.Property(e => e.IdEconomicSector).HasColumnName("ID_EconomicSector");

            entity.Property(e => e.NatureOfbusiness1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NatureOfbusiness");

            entity.HasOne(d => d.IdEconomicSectorNavigation)
                .WithMany(p => p.NatureOfbusinesses)
                .HasForeignKey(d => d.IdEconomicSector)
                .HasConstraintName("FK_NatureOfbusiness_EconomicSector");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.IdNotification);

            entity.ToTable("Notification");

            entity.Property(e => e.IdNotification).HasColumnName("ID_Notification");

            entity.Property(e => e.BranchName).HasMaxLength(100);

            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.Property(e => e.DateRead).HasColumnType("datetime");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(10)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdBranch)
                .HasMaxLength(500)
                .HasColumnName("ID_Branch");

            entity.Property(e => e.IdNotificationModule).HasColumnName("Id_NotificationModule");

            entity.Property(e => e.LastDateSent).HasColumnType("datetime");

            entity.Property(e => e.Message).HasMaxLength(1000);
        });

        modelBuilder.Entity<NotificationModuleUserGroup>(entity =>
        {
            entity.ToTable("NotificationModule_UserGroup");

            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");

            entity.Property(e => e.IdNotificationModule).HasColumnName("Id_NotificationModule");
        });

        modelBuilder.Entity<OnlineUser>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("OnlineUser");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FirstName).HasMaxLength(50);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.LastDeactivatedDate).HasColumnType("datetime");

            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.Property(e => e.LastPasswordResetDate).HasColumnType("datetime");

            entity.Property(e => e.LastReactivatedDate).HasColumnType("datetime");

            entity.Property(e => e.NextPasswordChangeDate).HasColumnType("datetime");

            entity.Property(e => e.Password).HasMaxLength(3000);

            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<OnlineUserAccount>(entity =>
        {
            entity.HasKey(e => e.IdOnlineUserAccount);

            entity.ToTable("OnlineUserAccount");

            entity.Property(e => e.IdOnlineUserAccount).HasColumnName("ID_OnlineUserAccount");

            entity.Property(e => e.AccountCode)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.Property(e => e.Email).HasMaxLength(250);

            entity.Property(e => e.LastDeactivatedDate).HasColumnType("datetime");

            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

            entity.Property(e => e.LastPasswordResetDate).HasColumnType("datetime");

            entity.Property(e => e.LoginPin).HasMaxLength(50);

            entity.Property(e => e.NextPasswordChangeDate).HasColumnType("datetime");

            entity.Property(e => e.Password).HasMaxLength(1000);

            entity.Property(e => e.PasswordSalt).HasMaxLength(1000);

            entity.Property(e => e.ProfileImage).HasColumnType("image");

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<PasswordChangeHistory>(entity =>
        {
            entity.HasKey(e => e.IdPasswordChangeHistory);

            entity.ToTable("PasswordChangeHistory");

            entity.Property(e => e.IdPasswordChangeHistory).HasColumnName("ID_PasswordChangeHistory");

            entity.Property(e => e.ChangeDate).HasColumnType("datetime");

            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<PasswordResetRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId)
                .HasName("PK_PasswordResetRequest1");

            entity.ToTable("PasswordResetRequest");

            entity.Property(e => e.Email).HasMaxLength(50);

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

            entity.Property(e => e.Token).HasMaxLength(50);
        });

        modelBuilder.Entity<ProfilePicture>(entity =>
        {
            entity.HasKey(e => e.IdProfilePicture);

            entity.ToTable("ProfilePicture");

            entity.Property(e => e.IdProfilePicture).HasColumnName("ID_ProfilePicture");

            entity.Property(e => e.Avatar).HasColumnType("text");

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<ReadNotification>(entity =>
        {
            entity.ToTable("ReadNotification");

            entity.Property(e => e.DateRead).HasColumnType("datetime");

            entity.Property(e => e.IdNotification).HasColumnName("ID_Notification");

            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<ReceiptType>(entity =>
        {
            entity.HasKey(e => e.IdReceiptType);

            entity.ToTable("ReceiptType");

            entity.Property(e => e.IdReceiptType).HasColumnName("ID_ReceiptType");

            entity.Property(e => e.ReceiptType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ReceiptType");
        });

        modelBuilder.Entity<RelationShip>(entity =>
        {
            entity.HasKey(e => e.IdRelationShip);

            entity.ToTable("RelationShip");

            entity.HasIndex(e => e.RelationShip1, "Key_RelationShip_RelationShip");

            entity.Property(e => e.IdRelationShip).HasColumnName("ID_RelationShip");

            entity.Property(e => e.RelationShip1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RelationShip");
        });

        modelBuilder.Entity<RiskChekList>(entity =>
        {
            entity.HasKey(e => e.IdRiskCheck);

            entity.ToTable("RiskChekList");

            entity.Property(e => e.IdRiskCheck).HasColumnName("ID_RiskCheck");

            entity.Property(e => e.RiskClass)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.RiskDescription)
                .HasMaxLength(2048)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SentUserAccount>(entity =>
        {
            entity.ToTable("SentUserAccount");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<SignatoryClassOld>(entity =>
        {
            entity.HasKey(e => e.IdSignatoryClass)
                .HasName("PK_SignatoryClass");

            entity.ToTable("SignatoryClass_Old");

            entity.Property(e => e.IdSignatoryClass)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_SignatoryClass");

            entity.Property(e => e.SignatoryClass)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SignatoryOld>(entity =>
        {
            entity.HasKey(e => e.IdSignatory)
                .HasName("PK_Signatory");

            entity.ToTable("Signatory_Old");

            entity.HasIndex(e => e.FullName, "Key_Signatory_FullName")
                .IsUnique();

            entity.HasIndex(e => e.SecUserId, "Key_Signatory_SecUserID")
                .IsUnique();

            entity.Property(e => e.IdSignatory).HasColumnName("ID_Signatory");

            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdSignatoryClass)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_SignatoryClass");

            entity.Property(e => e.SecUserId).HasColumnName("SecUserID");

            entity.Property(e => e.Sign1Amount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Sign2Amount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.SignatoryLevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Signature).HasColumnType("image");

            entity.HasOne(d => d.IdSignatoryClassNavigation)
                .WithMany(p => p.SignatoryOlds)
                .HasForeignKey(d => d.IdSignatoryClass)
                .HasConstraintName("FK_Signatory_SignatoryClass");
        });

        modelBuilder.Entity<SignatoryWorkFlowOld>(entity =>
        {
            entity.HasKey(e => e.IdSignatoryWorkFlow)
                .HasName("PK_SignatoryWorkFlow");

            entity.ToTable("SignatoryWorkFlow_Old");

            entity.Property(e => e.IdSignatoryWorkFlow).HasColumnName("ID_SignatoryWorkFlow");

            entity.Property(e => e.FromAmount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.IdSignatory1Class)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Signatory1Class");

            entity.Property(e => e.IdSignatory2Class)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_Signatory2Class");

            entity.Property(e => e.InvestmentRange)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ToAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdSignatory1ClassNavigation)
                .WithMany(p => p.SignatoryWorkFlowOldIdSignatory1ClassNavigations)
                .HasForeignKey(d => d.IdSignatory1Class)
                .HasConstraintName("FK_SignatoryWorkFlow_Signatory1Class");

            entity.HasOne(d => d.IdSignatory2ClassNavigation)
                .WithMany(p => p.SignatoryWorkFlowOldIdSignatory2ClassNavigations)
                .HasForeignKey(d => d.IdSignatory2Class)
                .HasConstraintName("FK_SignatoryWorkFlow_Signatory2Class");
        });

        modelBuilder.Entity<Smtpsetting>(entity =>
        {
            entity.ToTable("SMTPSettings");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.AuthPassWord)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.AuthUser)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.EnableSsl).HasColumnName("EnableSSL");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.MailType)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.Property(e => e.ReplyToAddress)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.SecureEmailAlways).HasColumnName("SecureEmail_Always");

            entity.Property(e => e.SecureEmailStartTls).HasColumnName("SecureEmail_StartTLS");

            entity.Property(e => e.SenderAddress)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.SenderName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Smtphost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMTPHost");

            entity.Property(e => e.Smtpport)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SMTPPort");
        });

        modelBuilder.Entity<SourceOfFund>(entity =>
        {
            entity.HasKey(e => e.IdSourceOfFund);

            entity.ToTable("SourceOfFund");

            entity.HasIndex(e => e.SourceOfFund1, "Key_SourceOfFund_SouceOfFund")
                .IsUnique();

            entity.Property(e => e.IdSourceOfFund)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_SourceOfFund");

            entity.Property(e => e.SourceOfFund1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("SourceOfFund");
        });

        modelBuilder.Entity<StatusMeaning>(entity =>
        {
            entity.HasKey(e => e.Status);

            entity.ToTable("StatusMeaning");

            entity.HasIndex(e => e.StatusName, "Key_StatusMeaning_Name")
                .IsUnique();

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tblist>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("tblist");

            entity.Property(e => e.IdUcidlist)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_UCIDList");

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<Tbprice>(entity =>
        {
            entity.HasKey(e => e.IdTbprice);

            entity.ToTable("TBPrices");

            entity.HasIndex(e => new { e.EffectiveDate, e.MaturityDate, e.IdTransMarket }, "Key_TBPrices_EffectiveDate");

            entity.Property(e => e.IdTbprice).HasColumnName("ID_TBPrice");

            entity.Property(e => e.BidDiscount)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("Bid_Discount");

            entity.Property(e => e.BidYield)
                .HasColumnType("decimal(18, 14)")
                .HasColumnName("Bid_Yield");

            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

            entity.Property(e => e.IdTransMarket).HasColumnName("ID_TransMarket");

            entity.Property(e => e.MaturityDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TmpBorrowList>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("TmpBorrowList");

            entity.Property(e => e.IdBorrowMaster).HasColumnName("ID_BorrowMaster");

            entity.Property(e => e.IdBorrowType)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ID_BorrowType");

            entity.Property(e => e.IdBrwlist)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Brwlist");

            entity.Property(e => e.IdPortfolioContributor).HasColumnName("ID_PortfolioContributor");
        });

        modelBuilder.Entity<TmpPrtCtbIdlist>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("TmpPrtCtbIDlist");

            entity.Property(e => e.DatabaseName)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.IdList)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_List");

            entity.Property(e => e.IdPortfolioContributor).HasColumnName("ID_PortfolioContributor");
        });

        modelBuilder.Entity<TmpPrtlist>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("TmpPrtlist");

            entity.Property(e => e.DatabaseName)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.IdPortfolio).HasColumnName("ID_Portfolio");

            entity.Property(e => e.IdPortfolioContributor).HasColumnName("ID_PortfolioContributor");

            entity.Property(e => e.IdTmpPrtlist)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_TmpPrtlist");
        });

        modelBuilder.Entity<UserApplication>(entity =>
        {
            entity.HasKey(e => e.IdUserApplication);

            entity.ToTable("UserApplication");

            entity.Property(e => e.IdUserApplication).HasColumnName("ID_UserApplication");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(10)
                .HasColumnName("ID_Application")
                .IsFixedLength();
        });

        modelBuilder.Entity<UserBranch>(entity =>
        {
            entity.HasKey(e => e.IdUserBranch);

            entity.ToTable("UserBranch");

            entity.Property(e => e.IdUserBranch).HasColumnName("ID_UserBranch");
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.IdUserGroup);

            entity.ToTable("UserGroup");

            entity.Property(e => e.IdUserGroup)
                .HasColumnName("ID_UserGroup")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
        });

        modelBuilder.Entity<ValBrkDwn>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("ValBrkDwn");

            entity.Property(e => e.Asset)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.AssetClass)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.AssetValue).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Currency)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.DatabaseName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.IdPortfolio).HasColumnName("ID_Portfolio");

            entity.Property(e => e.IdValBrkDwn)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_ValBrkDwn");

            entity.Property(e => e.InvestmentModule)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.ValuationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VfdBankApierrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorLogId);

            entity.ToTable("VfdBankAPIErrorLog");

            entity.Property(e => e.ApiendPoint)
                .HasMaxLength(500)
                .HasColumnName("APIEndPoint");

            entity.Property(e => e.ErrorCode)
                .HasMaxLength(5)
                .IsFixedLength();

            entity.Property(e => e.ErrorDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VfdBankOutwardTransferLog>(entity =>
        {
            entity.HasKey(e => e.InflowTransferId)
                .HasName("PK_VfdBankInwardTransferLog_1");

            entity.ToTable("VfdBankOutwardTransferLog");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FromAccount)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.FromClient).HasMaxLength(50);

            entity.Property(e => e.ToAccount)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.ToBank).HasMaxLength(50);

            entity.Property(e => e.ToClient).HasMaxLength(150);

            entity.Property(e => e.TransRef).HasMaxLength(50);

            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VfdBankWebHookLog>(entity =>
        {
            entity.HasKey(e => e.WebHookReqId);

            entity.ToTable("VfdBankWebHookLog");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.DateLogged).HasColumnType("datetime");

            entity.Property(e => e.OriginAccount)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.OriginAccountName).HasMaxLength(50);

            entity.Property(e => e.OriginBank)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.OriginNarration).HasMaxLength(1000);

            entity.Property(e => e.RawPayload).HasColumnType("text");

            entity.Property(e => e.ReferenceNo).HasMaxLength(50);

            entity.Property(e => e.TransactionTimeStamp).HasMaxLength(50);

            entity.Property(e => e.WalletAccountNo)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
