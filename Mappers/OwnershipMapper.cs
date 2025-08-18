using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Ownerships;
using api.Models;

namespace api.Mappers
{
    public static class OwnershipMapper
    {
        public static Ownership ToOwnership(this OwnershipDto ownershipDto)
        {
            return new Ownership
            {
                AccountId = ownershipDto.AccountId,
                StockId = ownershipDto.StockId,
                Owned = ownershipDto.Amount,
            };
        }

        public static OwnershipDto ToOwnershipDto(this Ownership ownership)
        {
            return new OwnershipDto
            {
                Id = ownership.Id,
                AccountId = ownership.AccountId,
                StockId = ownership.StockId,
                Amount = ownership.Owned
            };
        }
    }
}