using IbsRestApi.Entities.DmsMoneyBook;
using Microsoft.EntityFrameworkCore;

namespace IbsRestApi.Persistence;

public partial class DmsMoneyBookContext : DbContext
{
    public DmsMoneyBookContext()
    {
    }

    public DmsMoneyBookContext(DbContextOptions<DmsMoneyBookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountMandate> AccountMandates { get; set; } = null!;
    public virtual DbSet<CustomerPhoto> CustomerPhotos { get; set; } = null!;
    public virtual DbSet<DocumentServer> DocumentServers { get; set; } = null!;
    public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
    public virtual DbSet<IbsPeopleKyc> IbsPeopleKycs { get; set; } = null!;
    public virtual DbSet<KycChecklist> KycChecklists { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountMandate>(entity =>
        {
            entity.HasKey(e => e.IdAccountMandate);

            entity.ToTable("AccountMandate");

            entity.HasIndex(e => e.Ucid, "Key_AccountMandate_UCID");

            entity.Property(e => e.IdAccountMandate).HasColumnName("ID_AccountMandate");

            entity.Property(e => e.CapturedBy)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CapturedDate).HasColumnType("datetime");

            entity.Property(e => e.Mandate).HasColumnType("image");

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<CustomerPhoto>(entity =>
        {
            entity.HasKey(e => e.IdCustomerPhoto);

            entity.ToTable("CustomerPhoto");

            entity.HasIndex(e => new { e.Ucid, e.IdJointMember }, "Key_CustomerPhoto_UCID")
                .IsUnique();

            entity.Property(e => e.IdCustomerPhoto).HasColumnName("ID_CustomerPhoto");

            entity.Property(e => e.IdJointMember).HasColumnName("ID_JointMember");

            entity.Property(e => e.ImageExt)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.PhotoImage).HasColumnType("image");

            entity.Property(e => e.Ucid).HasColumnName("UCID");
        });

        modelBuilder.Entity<DocumentServer>(entity =>
        {
            entity.HasKey(e => e.IdDocumentServer);

            entity.ToTable("DocumentServer");

            entity.HasIndex(e => e.IdDocumentType, "Key_DocumentServer_DocType");

            entity.HasIndex(e => e.IdRequisitionMaster, "Key_DocumentServer_RequsitionMaster");

            entity.HasIndex(e => e.SearchKey, "Key_DocumentServer_SearchKey");

            entity.Property(e => e.IdDocumentServer).HasColumnName("ID_DocumentServer");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.DocImage).HasColumnType("image");

            entity.Property(e => e.IdDocumentType).HasColumnName("ID_DocumentType");

            entity.Property(e => e.IdRequisitionMaster).HasColumnName("ID_RequisitionMaster");

            entity.Property(e => e.ImageExt)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.ImageFileName)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.SearchKey)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.SourceDbName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("DocumentType");

            entity.Property(e => e.DocumentType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DocumentType");

            entity.Property(e => e.IdDocumentType)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_DocumentType");
        });

        modelBuilder.Entity<IbsPeopleKyc>(entity =>
        {
            entity.HasKey(e => e.IdKyc);

            entity.ToTable("IbsPeopleKYC");

            entity.HasIndex(e => e.IdKycCheckList, "Key_IbsPeopleKYC_CheckList");

            entity.HasIndex(e => e.Ucid, "Key_IbsPeopleKYC_UCID");

            entity.Property(e => e.IdKyc).HasColumnName("ID_KYC");

            entity.Property(e => e.ActionBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ActionDate).HasColumnType("datetime");

            entity.Property(e => e.DocImage).HasColumnType("image");

            entity.Property(e => e.FileExtension)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.Property(e => e.IdKycCheckList).HasColumnName("ID_KycCheckList");

            entity.Property(e => e.Ucid).HasColumnName("UCID");

            entity.Property(e => e.VerifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.VerifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdKycCheckListNavigation)
                .WithMany(p => p.IbsPeopleKycs)
                .HasForeignKey(d => d.IdKycCheckList)
                .HasConstraintName("FK_IbsPeopleKYC_KycChecklist");
        });

        modelBuilder.Entity<KycChecklist>(entity =>
        {
            entity.HasKey(e => e.IdKycCheckList);

            entity.ToTable("KycChecklist");

            entity.Property(e => e.IdKycCheckList).HasColumnName("ID_KycCheckList");

            entity.Property(e => e.CheckList)
                .HasMaxLength(1024)
                .IsUnicode(false);

            entity.Property(e => e.CustomerTypeList)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RiskProfileList)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
