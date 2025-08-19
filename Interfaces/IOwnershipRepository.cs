using api.Dtos.Ownerships;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IOwnershipRepository
    {
        Task<List<Ownership>> GetAll(OwnershipQueryObject query);
        Task<Ownership?> CreateOwnershipAsync(OwnershipDto ownershipDto);
        Task<Ownership?> UpdateOwnershipAsync(OwnershipDto ownershipDto);
        Task<Ownership?> DeleteOwnershipAsync(OwnershipDto ownershipDto);
    }
}