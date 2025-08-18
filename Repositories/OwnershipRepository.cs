using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Ownerships;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class OwnershipRepository(ApplicationDBContext context) : IOwnershipRepository
    {
        private readonly ApplicationDBContext _context = context;
        public async Task<Ownership?> CreateOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = ownershipDto.ToOwnership();
            await _context.AddAsync(ownership);
            await _context.SaveChangesAsync();
            return ownership;
        }

        public async Task<Ownership?> DeleteOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _context.Ownerships.FirstOrDefaultAsync(o => o.Id == ownershipDto.Id);
            if (ownership == null) return null;
            _context.Remove(ownership);
            _context.SaveChanges();
            return ownership;
        }

        public List<Task<Ownership>> GetAll(OwnershipQueryObject query)
        {
            throw new NotImplementedException();
        }

        public async Task<Ownership?> UpdateOwnershipAsync(OwnershipDto ownershipDto)
        {
            var ownership = await _context.Ownerships.FirstOrDefaultAsync(o => o.Id == ownershipDto.Id);
            if (ownership == null) return null;
            ownership.AccountId = ownershipDto.AccountId;
            ownership.StockId = ownershipDto.StockId;
            ownership.Owned = ownershipDto.Amount;
            await _context.SaveChangesAsync();
            return ownership;
        }
    }
}