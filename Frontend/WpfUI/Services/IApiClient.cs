using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WpfUI.Models;

namespace WpfUI.Services;

public interface IApiClient
{
    Task HealthPingAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ItemDto>> GetItemsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<WarehouseDto>> GetWarehousesAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProposalDto>> GetProposalsAsync(CancellationToken cancellationToken = default);
    Task SendContactMessageAsync(ContactMessage message, CancellationToken cancellationToken = default);
}
