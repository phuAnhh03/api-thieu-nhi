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

        public async Task<List<Ownership>> GetAll(OwnershipQueryObject query)
        {
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var ownerships = _context.Ownerships.AsQueryable();
            return await ownerships.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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