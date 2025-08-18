using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Ownerships;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IOwnershipService
    {
        List<Task<OwnershipDto>> ListAll(OwnershipQueryObject query);
        Task<OwnershipDto?> AddOwnershipAsync(OwnershipDto ownershipDto);
        Task<OwnershipDto?> EditOwnershipAsync(OwnershipDto ownershipDto);
        Task<bool?> RemoveOwnershipAsync(OwnershipDto ownershipDto);
    }
}