namespace PropEditorApi.Model;

public class Proposal
{
    public string ItemId { get; set; } = string.Empty;
    public string WarehouseId { get; set; } = string.Empty;
    public int ProposalIndex { get; set; }
    public decimal? Quantity { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public DateOnly? DueDate { get; set; }
}
