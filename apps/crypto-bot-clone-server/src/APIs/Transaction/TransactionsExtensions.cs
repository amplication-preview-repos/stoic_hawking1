using CryptoBotClone.APIs.Dtos;
using CryptoBotClone.Infrastructure.Models;

namespace CryptoBotClone.APIs.Extensions;

public static class TransactionsExtensions
{
    public static Transaction ToDto(this TransactionDbModel model)
    {
        return new Transaction
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Currency = model.Currency,
            Id = model.Id,
            Receiver = model.Receiver,
            Sender = model.Sender,
            Status = model.Status,
            TransactionDate = model.TransactionDate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TransactionDbModel ToModel(
        this TransactionUpdateInput updateDto,
        TransactionWhereUniqueInput uniqueId
    )
    {
        var transaction = new TransactionDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Currency = updateDto.Currency,
            Receiver = updateDto.Receiver,
            Sender = updateDto.Sender,
            Status = updateDto.Status,
            TransactionDate = updateDto.TransactionDate
        };

        if (updateDto.CreatedAt != null)
        {
            transaction.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            transaction.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return transaction;
    }
}
