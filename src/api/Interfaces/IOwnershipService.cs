using api.Dtos.Ownerships;
using api.Helpers;

namespace api.Interfaces
{
    public interface IOwnershipService
    {
        Task<List<GetOwnershipDto>> ListAll(OwnershipQueryObject query);
        Task<GetOwnershipDto?> AddOwnershipAsync(OwnershipDto ownershipDto);
        Task<GetOwnershipDto?> EditOwnershipAsync(OwnershipDto ownershipDto);
        Task<bool?> RemoveOwnershipAsync(OwnershipDto ownershipDto);
    }
}