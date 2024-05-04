using NftScanner.Wrapper.Entity.BlockFrost;

namespace NftScanner.Wrapper
{
    /// <summary>
    /// Interface to Block Frost Api 
    /// </summary>
    internal interface IBlockFrost
  {
    /// <summary>
    /// Get Transactions
    /// </summary>
    /// <returns></returns>
    Task<TransactionResponse?> GetTransactions(string hash);

    /// <summary>
    /// Get Specific Asset
    /// </summary>
    /// <returns></returns>
    Task<AssetResponse?> GetSpecificAsset(string hash);
  }
}
