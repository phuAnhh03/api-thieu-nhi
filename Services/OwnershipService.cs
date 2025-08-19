using api.Dtos.Ownerships;
using api.Helpers;
using api.Interfaces;
using api.Mappers;

namespace api.Services
{
    public class OwnershipService(IOwnershipRepository ownershipRepository) : IOwnershipService
    {
        private readonly IOwnershipRepository _ownershipRepository = ownershipRepository;

        public async Task<OwnershipDto?> AddOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipRepository.CreateOwnershipAsync(ownershipDto);
            if (ownership == null) return null;
            var result = ownership.ToOwnershipDto();
            return result;
        }

        public async Task<OwnershipDto?> EditOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipRepository.UpdateOwnershipAsync(ownershipDto);
            if (ownership == null) return null;
            var result = ownership.ToOwnershipDto();
            return result;
        }

        public async Task<List<OwnershipDto>> ListAll(OwnershipQueryObject query)
        {
            var ownership = await _ownershipRepository.GetAll(query);
           return ownership.Select(x => x.ToOwnershipDto()).ToList();
        }

        public async Task<bool?> RemoveOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipRepository.UpdateOwnershipAsync(ownershipDto);
            if (ownership == null) return null;
            return true;
        }
    }
}