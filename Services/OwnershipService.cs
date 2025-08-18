using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Ownerships;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Repositories;

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

        public List<Task<OwnershipDto>> ListAll(OwnershipQueryObject query)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> RemoveOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _ownershipRepository.UpdateOwnershipAsync(ownershipDto);
            if (ownership == null) return null;
            return true;
        }
    }
}