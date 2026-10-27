namespace PropEditorApi.Model;

public class Item
{
    public string ItemId { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FamilyId { get; set; }
    public string? SupplierId { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? UnitVol { get; set; }
    public decimal? ListPrice { get; set; }
}
