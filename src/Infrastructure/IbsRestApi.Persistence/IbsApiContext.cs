using Ibs.Persistence.IbsAPIEntities;
using IbsRestApi.Entities.IbsAPI;
using Microsoft.EntityFrameworkCore;

namespace IbsRestApi.Persistence;
public partial class IbsApiContext : DbContext
{
    public IbsApiContext()
    {

    }
    public IbsApiContext(DbContextOptions<IbsApiContext> options)
        : base(options)
    {
    }


    public virtual DbSet<APIUser> APIUser { get; set; } = null!;

    public virtual DbSet<ActivityLog> ActivityLog { get; set; } = null!;

    public virtual DbSet<LoginToken> LoginToken { get; set; } = null!;
    public virtual DbSet<APITokenUser> APITokenUser { get; set; } = null!;




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<LoginToken>(entity =>
        {
            entity.HasKey(e => e.LoginTokenID);
            entity.Property(e => e.LoginTokenID)
            .HasColumnName("ID");
        });

        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.ActivityLogId);
            entity.Property(e => e.ActivityLogId)
            .HasColumnName("ID_ActivityLog");
        });
        
        modelBuilder.Entity<APITokenUser>(entity =>
        {
            entity.HasKey(e => e.APITokenUserId);
            entity.Property(e => e.APITokenUserId)
            .HasColumnName("ID_APITokenUser");
        });

        modelBuilder.Entity<APIUser>(entity =>
        {
            entity.HasKey(e => e.ApiUserId);

            entity.Property(e => e.ApiUserId)
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.APIKey)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.APISecret)
             .IsRequired()
             .HasMaxLength(50);

            entity.Property(e => e.UserName)
             .IsRequired()
             .HasMaxLength(150);

            entity.Property(e => e.Status)
             .IsRequired()
             .HasDefaultValueSql("(1)");

            entity.Property(e => e.DateCreated)
              .IsRequired()
              .HasDefaultValueSql("(getDate())");


        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
