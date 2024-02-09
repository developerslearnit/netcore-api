using IbsRestApi.Entities.Secure;
using Microsoft.EntityFrameworkCore;

namespace IbsRestApi.Persistence;

public partial class SecureContext : DbContext
{
   
    public SecureContext(DbContextOptions<SecureContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlertNotification> AlertNotifications { get; set; } = null!;
    public virtual DbSet<AppBranch> AppBranches { get; set; } = null!;
    public virtual DbSet<AppConfigSetting> AppConfigSettings { get; set; } = null!;
    public virtual DbSet<AppExceptionLog> AppExceptionLogs { get; set; } = null!;
    public virtual DbSet<Application> Applications { get; set; } = null!;
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
    public virtual DbSet<CategoryList> CategoryLists { get; set; } = null!;
    public virtual DbSet<CurrentConnection> CurrentConnections { get; set; } = null!;
    public virtual DbSet<Group> Groups { get; set; } = null!;
    public virtual DbSet<GroupMenu> GroupMenus { get; set; } = null!;
    public virtual DbSet<IbsSecuritySetting> IbsSecuritySettings { get; set; } = null!;
    public virtual DbSet<IpaddressBlacklist> IpaddressBlacklists { get; set; } = null!;
    public virtual DbSet<Menu> Menus { get; set; } = null!;
    public virtual DbSet<Otprepository> Otprepositories { get; set; } = null!;
    public virtual DbSet<PasswordChangeHistory> PasswordChangeHistories { get; set; } = null!;
    public virtual DbSet<PasswordResetRequest> PasswordResetRequests { get; set; } = null!;
    public virtual DbSet<PaymentChannel> PaymentChannels { get; set; } = null!;
    public virtual DbSet<ProtectedResource> ProtectedResources { get; set; } = null!;
    public virtual DbSet<ResetRequest> ResetRequests { get; set; } = null!;
    public virtual DbSet<SecurityAccessGrid> SecurityAccessGrids { get; set; } = null!;
    public virtual DbSet<SecurityCategory> SecurityCategories { get; set; } = null!;
    public virtual DbSet<SecurityDetail> SecurityDetails { get; set; } = null!;
    public virtual DbSet<SecurityGroup> SecurityGroups { get; set; } = null!;
    public virtual DbSet<SecurityGroupAccess> SecurityGroupAccesses { get; set; } = null!;
    public virtual DbSet<SecurityGroupMember> SecurityGroupMembers { get; set; } = null!;
    public virtual DbSet<SecurityRole> SecurityRoles { get; set; } = null!;
    public virtual DbSet<Signatory> Signatories { get; set; } = null!;
    public virtual DbSet<SignatoryClass> SignatoryClasses { get; set; } = null!;
    public virtual DbSet<SignatoryWorkFlow> SignatoryWorkFlows { get; set; } = null!;
    public virtual DbSet<Smtpsetting> Smtpsettings { get; set; } = null!;
    public virtual DbSet<UserApplication> UserApplications { get; set; } = null!;
    public virtual DbSet<UserBranch> UserBranches { get; set; } = null!;
    public virtual DbSet<UserDepartment> UserDepartments { get; set; } = null!;
    public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;
    public virtual DbSet<WebAnnouncement> WebAnnouncements { get; set; } = null!;
    public virtual DbSet<WebUser> WebUsers { get; set; } = null!;
    public virtual DbSet<WebUserRole> WebUserRoles { get; set; } = null!;
    public virtual DbSet<WxAuditLog> WxAuditLogs { get; set; } = null!;
    public virtual DbSet<WxPreference> WxPreferences { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlertNotification>(entity =>
        {
            entity.HasKey(e => e.IdAlertNotification);

            entity.ToTable("AlertNotification");

            entity.HasIndex(e => new { e.IdApplication, e.ToWebUsers }, "Key_AlertNotification_Speed01");

            entity.HasIndex(e => e.ToWebUsers, "Key_AlertNotification_WeUserID");

            entity.Property(e => e.IdAlertNotification).HasColumnName("ID_AlertNotification");

            entity.Property(e => e.AlertDate).HasColumnType("datetime");

            entity.Property(e => e.AlertSubject)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Dbid).HasColumnName("DBID");

            entity.Property(e => e.FromWebUserId).HasColumnName("FromWebUserID");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdOriginAppId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Origin_AppID");

            entity.Property(e => e.PageName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.RepliedWebUserId).HasColumnName("RepliedWebUserID");

            entity.Property(e => e.TheMessage)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.ToWebUsers)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.TreatedDate).HasColumnType("datetime");

            entity.Property(e => e.UniqueRecId)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("UniqueRecID");
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

            entity.Property(e => e.Dbid)
                .ValueGeneratedOnAdd()
                .HasColumnName("DBID");

            entity.Property(e => e.GrpLifeDbName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(5)
                .HasColumnName("ID_Application");

            entity.Property(e => e.MoneyBookDatabase).HasMaxLength(150);

            entity.Property(e => e.MultiPlanDbName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Sensitivity)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.ServerName).HasMaxLength(150);

            entity.Property(e => e.TakaFulDbName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AppConfigSetting>(entity =>
        {
            entity.HasKey(e => e.ConfigId);

            entity.ToTable("AppConfigSetting");

            entity.HasIndex(e => e.ConfigKey, "Key_AppConfigSetting_ConfigKey")
                .IsUnique();

            entity.Property(e => e.ConfigKey).HasMaxLength(200);
        });

        modelBuilder.Entity<AppExceptionLog>(entity =>
        {
            entity.HasKey(e => e.IdErrorLog)
                .HasName("PK_dbo.AppExceptionLog");

            entity.ToTable("AppExceptionLog");

            entity.Property(e => e.IdErrorLog).HasColumnName("ID_ErrorLog");

            entity.Property(e => e.ActionName).HasMaxLength(500);

            entity.Property(e => e.AreaName).HasMaxLength(500);

            entity.Property(e => e.ControllerName).HasMaxLength(500);

            entity.Property(e => e.ErrorMessage).HasMaxLength(2000);

            entity.Property(e => e.ErrorSource).HasMaxLength(500);

            entity.Property(e => e.ErrorType).HasMaxLength(500);

            entity.Property(e => e.ErrorXml).HasColumnName("ErrorXML");

            entity.Property(e => e.LoggedInUser).HasMaxLength(300);

            entity.Property(e => e.TimeUtc)
                .HasColumnType("datetime")
                .HasColumnName("TimeUTC");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.IdApplication);

            entity.Property(e => e.IdApplication).HasColumnName("ID_Application");

            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(5)
                .IsFixedLength();

            entity.Property(e => e.ApplicationName).HasMaxLength(100);

            entity.Property(e => e.ApplicationUri).HasMaxLength(150);
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

            entity.Property(e => e.PasswordSalt).HasMaxLength(250);

            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<CategoryList>(entity =>
        {
            entity.HasKey(e => e.Category);

            entity.ToTable("CategoryList");

            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CurrentConnection>(entity =>
        {
            entity.ToTable("CurrentConnection");

            entity.Property(e => e.CurrentConnectionId).HasColumnName("CurrentConnectionID");

            entity.Property(e => e.BrowserPlatform)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.BrowserType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.BrowserVersion)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CurrentPage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IPAddress");

            entity.Property(e => e.LastActivity).HasColumnType("datetime");

            entity.Property(e => e.SessionBegan).HasColumnType("datetime");

            entity.Property(e => e.SessionEnd).HasColumnType("datetime");

            entity.Property(e => e.SessionId)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("SessionID");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.WebUserId).HasColumnName("WebUserID");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.Property(e => e.IdGroup)
                .HasColumnName("ID_Group")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.GroupName).HasMaxLength(50);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .HasColumnName("ID_Application")
                .IsFixedLength();
        });

        modelBuilder.Entity<GroupMenu>(entity =>
        {
            entity.HasKey(e => e.IdGroupMenu);

            entity.ToTable("GroupMenu");

            entity.Property(e => e.IdGroupMenu).HasColumnName("ID_GroupMenu");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");

            entity.Property(e => e.IdMenu).HasColumnName("ID_Menu");
        });

        modelBuilder.Entity<IbsSecuritySetting>(entity =>
        {
            entity.HasKey(e => e.IdIbsSecuritySetting);

            entity.ToTable("IbsSecuritySetting");

            entity.Property(e => e.IdIbsSecuritySetting).HasColumnName("ID_IbsSecuritySetting");

            entity.Property(e => e.SettingKey).HasMaxLength(20);

            entity.Property(e => e.SettingValue).HasMaxLength(50);
        });

        modelBuilder.Entity<IpaddressBlacklist>(entity =>
        {
            entity.HasKey(e => e.IdIpaddressBlacklist);

            entity.ToTable("IPAddressBlacklist");

            entity.Property(e => e.IdIpaddressBlacklist).HasColumnName("ID_IPAddressBlacklist");

            entity.Property(e => e.AccessDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Country).HasMaxLength(60);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(10)
                .HasColumnName("ID_Application")
                .IsFixedLength();

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(20)
                .HasColumnName("IPAddress");

            entity.Property(e => e.LoginId)
                .HasMaxLength(50)
                .HasColumnName("LoginID");
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

        modelBuilder.Entity<Otprepository>(entity =>
        {
            entity.HasKey(e => e.RequestId)
                .HasName("PK_PasswordResetRequest");

            entity.ToTable("OTPRepository");

            entity.Property(e => e.RequestId).ValueGeneratedNever();

            entity.Property(e => e.AccountCode).HasMaxLength(50);

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");

            entity.Property(e => e.Email).HasMaxLength(50);

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
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

        modelBuilder.Entity<PaymentChannel>(entity =>
        {
            entity.HasKey(e => e.IdPaymentChannel);

            entity.ToTable("PaymentChannel");

            entity.Property(e => e.IdPaymentChannel).HasColumnName("ID_PaymentChannel");

            entity.Property(e => e.ChannelKey).HasMaxLength(100);

            entity.Property(e => e.ChannelLogo).HasMaxLength(2000);

            entity.Property(e => e.ChannelName).HasMaxLength(100);

            entity.Property(e => e.LivePublicKey).HasMaxLength(2000);

            entity.Property(e => e.LiveSecretKey).HasMaxLength(2000);

            entity.Property(e => e.TestPublicKey).HasMaxLength(2000);

            entity.Property(e => e.TestSecretKey).HasMaxLength(2000);
        });

        modelBuilder.Entity<ProtectedResource>(entity =>
        {
            entity.HasKey(e => e.IdProtectedResource);

            entity.ToTable("ProtectedResource");

            entity.Property(e => e.IdProtectedResource).HasColumnName("ID_ProtectedResource");

            entity.Property(e => e.ActionName).HasMaxLength(150);

            entity.Property(e => e.AreaName).HasMaxLength(150);

            entity.Property(e => e.ControllerName).HasMaxLength(150);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(10)
                .HasColumnName("ID_Application");
        });

        modelBuilder.Entity<ResetRequest>(entity =>
        {
            entity.ToTable("ResetRequest");

            entity.HasIndex(e => e.WebUserId, "IX_ResetRequest");

            entity.HasIndex(e => e.Hash, "IX_ResetRequest_1");

            entity.Property(e => e.ResetRequestId).HasColumnName("ResetRequestID");

            entity.Property(e => e.Hash).HasMaxLength(64);

            entity.Property(e => e.RequestDate).HasColumnType("datetime");

            entity.Property(e => e.WebUserId).HasColumnName("WebUserID");
        });

        modelBuilder.Entity<SecurityAccessGrid>(entity =>
        {
            entity.HasKey(e => e.IdSecurityAccessGrid);

            entity.ToTable("SecurityAccessGrid");

            entity.HasIndex(e => e.IdApplication, "Key_SecurityAccessGrid_AppID");

            entity.HasIndex(e => e.SecurityDetailId, "Key_SecurityAccessGrid_SecurityDetailID");

            entity.HasIndex(e => e.WebUserId, "Key_SecurityAccessGrid_WebUser");

            entity.Property(e => e.IdSecurityAccessGrid).HasColumnName("ID_SecurityAccessGrid");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdSecurityGroup).HasColumnName("ID_SecurityGroup");

            entity.Property(e => e.SecurityDetailId).HasColumnName("SecurityDetailID");

            entity.Property(e => e.WebUserId).HasColumnName("WebUserID");
        });

        modelBuilder.Entity<SecurityCategory>(entity =>
        {
            entity.ToTable("SecurityCategory");

            entity.HasIndex(e => e.SecurityRoleId, "IX_SecurityCategory");

            entity.HasIndex(e => e.WebUserId, "IX_SecurityCategory_1");

            entity.Property(e => e.SecurityCategoryId).HasColumnName("SecurityCategoryID");

            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.SecurityRoleId).HasColumnName("SecurityRoleID");

            entity.Property(e => e.WebUserId).HasColumnName("WebUserID");
        });

        modelBuilder.Entity<SecurityDetail>(entity =>
        {
            entity.ToTable("SecurityDetail");

            entity.HasIndex(e => e.IdApplication, "Key_SecurityDetail_ID_Application");

            entity.HasIndex(e => e.ItemName, "Key_SecurityDetail_ItemName");

            entity.HasIndex(e => e.ItemNameSearch, "Key_SecurityDetail_Unique")
                .IsUnique();

            entity.Property(e => e.SecurityDetailId).HasColumnName("SecurityDetailID");

            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ItemNameSearch)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SecurityGroup>(entity =>
        {
            entity.HasKey(e => e.IdSecurityGroup);

            entity.ToTable("SecurityGroup");

            entity.HasIndex(e => new { e.IdApplication, e.GroupName }, "Key_SecurityGroup_SecurityGroup")
                .IsUnique();

            entity.Property(e => e.IdSecurityGroup).HasColumnName("ID_SecurityGroup");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.Property(e => e.ExpireDate).HasColumnType("datetime");

            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.Notes).HasColumnType("text");
        });

        modelBuilder.Entity<SecurityGroupAccess>(entity =>
        {
            entity.HasKey(e => e.IdSecurityGroupAccess);

            entity.ToTable("SecurityGroupAccess");

            entity.Property(e => e.IdSecurityGroupAccess).HasColumnName("ID_SecurityGroupAccess");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdSecurityGroup).HasColumnName("ID_SecurityGroup");

            entity.Property(e => e.SecurityDetailId).HasColumnName("SecurityDetailID");

            entity.HasOne(d => d.IdSecurityGroupNavigation)
                .WithMany(p => p.SecurityGroupAccesses)
                .HasForeignKey(d => d.IdSecurityGroup)
                .HasConstraintName("FK_SecurityGroupAccess_SecurityGroup");
        });

        modelBuilder.Entity<SecurityGroupMember>(entity =>
        {
            entity.HasKey(e => e.IdGroupMenber);

            entity.ToTable("SecurityGroupMember");

            entity.Property(e => e.IdGroupMenber).HasColumnName("ID_GroupMenber");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ID_Application");

            entity.Property(e => e.IdSecurityGroup).HasColumnName("ID_SecurityGroup");

            entity.Property(e => e.WebUserId).HasColumnName("WebUserID");

            entity.HasOne(d => d.IdSecurityGroupNavigation)
                .WithMany(p => p.SecurityGroupMembers)
                .HasForeignKey(d => d.IdSecurityGroup)
                .HasConstraintName("FK_SecurityGroupMember_SecurityGroup");

            entity.HasOne(d => d.WebUser)
                .WithMany(p => p.SecurityGroupMembers)
                .HasForeignKey(d => d.WebUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SecurityGroupMember_WebUser");
        });

        modelBuilder.Entity<SecurityRole>(entity =>
        {
            entity.ToTable("SecurityRole");

            entity.Property(e => e.SecurityRoleId).HasColumnName("SecurityRoleID");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Signatory>(entity =>
        {
            entity.HasKey(e => e.IdSignatory);

            entity.ToTable("Signatory");

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
                .WithMany(p => p.Signatories)
                .HasForeignKey(d => d.IdSignatoryClass)
                .HasConstraintName("FK_Signatory_SignatoryClass");
        });

        modelBuilder.Entity<SignatoryClass>(entity =>
        {
            entity.HasKey(e => e.IdSignatoryClass);

            entity.ToTable("SignatoryClass");

            entity.Property(e => e.IdSignatoryClass)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ID_SignatoryClass");

            entity.Property(e => e.SignatoryClass1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SignatoryClass");
        });

        modelBuilder.Entity<SignatoryWorkFlow>(entity =>
        {
            entity.HasKey(e => e.IdSignatoryWorkFlow);

            entity.ToTable("SignatoryWorkFlow");

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
                .WithMany(p => p.SignatoryWorkFlowIdSignatory1ClassNavigations)
                .HasForeignKey(d => d.IdSignatory1Class)
                .HasConstraintName("FK_SignatoryWorkFlow_Signatory1Class");

            entity.HasOne(d => d.IdSignatory2ClassNavigation)
                .WithMany(p => p.SignatoryWorkFlowIdSignatory2ClassNavigations)
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

            entity.Property(e => e.SendViaApi).HasColumnName("SendViaAPI");

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

            entity.Property(e => e.UseSmtp).HasColumnName("UseSMTP");
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

        modelBuilder.Entity<UserDepartment>(entity =>
        {
            entity.HasKey(e => e.IdUserDepartment);

            entity.ToTable("UserDepartment");

            entity.Property(e => e.IdUserDepartment).HasColumnName("ID_UserDepartment");

            entity.Property(e => e.Department)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.ShortName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.IdUserGroup);

            entity.ToTable("UserGroup");

            entity.Property(e => e.IdUserGroup)
                .HasColumnName("ID_UserGroup")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.IdApplication)
                .HasMaxLength(5)
                .HasColumnName("ID_Application")
                .IsFixedLength();

            entity.Property(e => e.IdGroup).HasColumnName("ID_Group");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
        });

        modelBuilder.Entity<WebAnnouncement>(entity =>
        {
            entity.ToTable("WebAnnouncement");

            entity.Property(e => e.WebAnnouncementId)
                .ValueGeneratedNever()
                .HasColumnName("WebAnnouncementID");

            entity.Property(e => e.TheMessage).HasColumnType("text");
        });

        modelBuilder.Entity<WebUser>(entity =>
        {
            entity.ToTable("WebUser");

            entity.HasIndex(e => e.UserName, "Key_WebUser_UserName")
                .IsUnique();

            entity.Property(e => e.WebUserId).HasColumnName("WebUserID");

            entity.Property(e => e.AccountCode)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.Property(e => e.DisableDate).HasColumnType("datetime");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.FailedPasswordTries).HasDefaultValueSql("((0))");

            entity.Property(e => e.FirstName).HasMaxLength(100);

            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.IdUserDepartment).HasColumnName("ID_UserDepartment");

            entity.Property(e => e.LastDeactivatedDate).HasColumnType("datetime");

            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.Property(e => e.LastPasswordResetDate).HasColumnType("datetime");

            entity.Property(e => e.LastReactivatedDate).HasColumnType("datetime");

            entity.Property(e => e.LogoutDate).HasColumnType("datetime");

            entity.Property(e => e.MobilePhone)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NextPasswordChangeDate).HasColumnType("datetime");

            entity.Property(e => e.PassHash).HasMaxLength(64);

            entity.Property(e => e.PassportPhoto).HasColumnType("image");

            entity.Property(e => e.Password).HasMaxLength(1000);

            entity.Property(e => e.PasswordSalt).HasMaxLength(1000);

            entity.Property(e => e.Request4ResetDate).HasColumnType("datetime");

            entity.Property(e => e.SensivityLevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");

            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<WebUserRole>(entity =>
        {
            entity.ToTable("WebUserRole");

            entity.HasIndex(e => e.WebUserId, "IX_WebUserRole");

            entity.Property(e => e.WebUserRoleId).HasColumnName("WebUserRoleID");

            entity.Property(e => e.SecurityRoleId).HasColumnName("SecurityRoleID");

            entity.Property(e => e.WebUserId).HasColumnName("WebUserID");
        });

        modelBuilder.Entity<WxAuditLog>(entity =>
        {
            entity.HasKey(e => e.IdAuditLog);

            entity.ToTable("WxAuditLog");

            entity.HasIndex(e => e.Changetimestamp, "Key_AuditLog_ChangeTimeStamp");

            entity.HasIndex(e => new { e.UserId, e.Changetimestamp }, "Key_AuditLog_UserID_Datetime");

            entity.Property(e => e.IdAuditLog).HasColumnName("ID_AuditLog");

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

        modelBuilder.Entity<WxPreference>(entity =>
        {
            entity.HasKey(e => e.IdWxPreferences);

            entity.Property(e => e.IdWxPreferences).HasColumnName("ID_WxPreferences");

            entity.Property(e => e.AutoAssignLognId).HasColumnName("AutoAssignLognID");

            entity.Property(e => e.ComplianceMailList)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.CrystalReportFolder)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.DaysB4warnPwdExpire).HasColumnName("DaysB4WarnPwdExpire");

            entity.Property(e => e.ItmailList)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ITMailList");

            entity.Property(e => e.KycVerificationRequired).HasColumnName("KYC_VerificationRequired");

            entity.Property(e => e.MgtMailList)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.OperationsMailList)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.PortalUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PortalURL");

            entity.Property(e => e.ReCrystalUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ReCrystalURL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
