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

        public static GetOwnershipDto ToGetOwnershipDto(this Ownership ownership)
        {
            return new GetOwnershipDto
            {
                AccountId = ownership.AccountId,
                StockId = ownership.StockId,
                Amount = ownership.Owned
            };
        }
    }
}