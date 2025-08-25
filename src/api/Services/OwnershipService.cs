using api.Dtos.Ownerships;
using api.Helpers;
using api.Interfaces;
using api.Mappers;

namespace api.Services
{
    public class OwnershipService(IOwnershipRepository ownershipRepository) : IOwnershipService
    {
        private readonly IOwnershipRepository _ownershipRepository = ownershipRepository;

        public async Task<GetOwnershipDto?> AddOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipRepository.CreateOwnershipAsync(ownershipDto);
            if (ownership == null) return null;
            var result = ownership.ToGetOwnershipDto();
            return result;
        }

        public async Task<GetOwnershipDto?> EditOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipRepository.UpdateOwnershipAsync(ownershipDto);
            if (ownership == null) return null;
            var result = ownership.ToGetOwnershipDto();
            return result;
        }

        public async Task<List<GetOwnershipDto>> ListAll(OwnershipQueryObject query)
        {
            var ownership = await _ownershipRepository.GetAll(query);
           return ownership.Select(x => x.ToGetOwnershipDto()).ToList();
        }

        public async Task<bool?> RemoveOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipRepository.UpdateOwnershipAsync(ownershipDto);
            if (ownership == null) return null;
            return true;
        }
    }
}