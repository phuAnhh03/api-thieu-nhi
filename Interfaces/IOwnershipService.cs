using api.Dtos.Ownerships;
using api.Helpers;

namespace api.Interfaces
{
    public interface IOwnershipService
    {
        Task<List<OwnershipDto>> ListAll(OwnershipQueryObject query);
        Task<OwnershipDto?> AddOwnershipAsync(OwnershipDto ownershipDto);
        Task<OwnershipDto?> EditOwnershipAsync(OwnershipDto ownershipDto);
        Task<bool?> RemoveOwnershipAsync(OwnershipDto ownershipDto);
    }
}