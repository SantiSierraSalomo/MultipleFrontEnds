using Microsoft.EntityFrameworkCore;
using PropEditorApi.Model;

namespace PropEditorApi.Data;

public class PropEditorDbContext(DbContextOptions<PropEditorDbContext> options) : DbContext(options)
{
    public DbSet<Family> Families => Set<Family>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<Proposal> Proposals => Set<Proposal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Family>(entity =>
        {
            entity.ToTable("Family");
            entity.HasKey(x => x.FamilyId);
            entity.Property(x => x.FamilyId).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");
            entity.HasKey(x => x.SupplierId);
            entity.Property(x => x.SupplierId).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");
            entity.HasKey(x => x.ItemId);
            entity.Property(x => x.ItemId).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(100);
            entity.Property(x => x.FamilyId).HasMaxLength(50);
            entity.Property(x => x.SupplierId).HasMaxLength(50);
            entity.Property(x => x.UnitCost).HasColumnType("decimal(18,4)");
            entity.Property(x => x.UnitVol).HasColumnType("decimal(18,4)");
            entity.Property(x => x.ListPrice).HasColumnType("decimal(18,4)");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");
            entity.HasKey(x => x.WarehouseId);
            entity.Property(x => x.WarehouseId).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.ToTable("Proposals");
            entity.HasKey(x => new { x.ItemId, x.WarehouseId, x.ProposalIndex });
            entity.Property(x => x.ItemId).HasMaxLength(100).IsRequired();
            entity.Property(x => x.WarehouseId).HasMaxLength(50).IsRequired();
            entity.Property(x => x.ProposalIndex).HasColumnName("ProposalIndex").IsRequired();
            entity.Property(x => x.Quantity).HasColumnType("decimal(18,4)");
            entity.Property(x => x.ReleaseDate).HasColumnType("date");
            entity.Property(x => x.DueDate).HasColumnType("date");
        });
    }
}
