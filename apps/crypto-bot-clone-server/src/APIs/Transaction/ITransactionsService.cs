using CryptoBotClone.APIs.Common;
using CryptoBotClone.APIs.Dtos;

namespace CryptoBotClone.APIs;

public interface ITransactionsService
{
    /// <summary>
    /// Create one Transaction
    /// </summary>
    public Task<Transaction> CreateTransaction(TransactionCreateInput transaction);

    /// <summary>
    /// Delete one Transaction
    /// </summary>
    public Task DeleteTransaction(TransactionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Transactions
    /// </summary>
    public Task<List<Transaction>> Transactions(TransactionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Transaction records
    /// </summary>
    public Task<MetadataDto> TransactionsMeta(TransactionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Transaction
    /// </summary>
    public Task<Transaction> Transaction(TransactionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Transaction
    /// </summary>
    public Task UpdateTransaction(
        TransactionWhereUniqueInput uniqueId,
        TransactionUpdateInput updateDto
    );
}
