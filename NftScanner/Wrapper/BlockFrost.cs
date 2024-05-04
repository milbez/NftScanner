using NftScanner.Wrapper.Entity.BlockFrost;

namespace NftScanner.Wrapper
{
  /// <summary>
  /// Client to Block Frost Api 
  /// </summary>
  internal class BlockFrost : BaseWrapper, IBlockFrost
  {
    /// <summary>
    /// Client service URL
    /// </summary>
    protected override string GetClientUrl
    {
      get
      {
        return _settings.BlockFrostBaseUrl;
      }
    }

    public BlockFrost(AppSettings settings, IHttpClientFactory httpClientFactory)
      : base(settings, httpClientFactory)
    {
    }

    /// <summary>
    /// Get Transactions
    /// </summary>
    /// <param name="hash">Transaction Hash</param>
    /// <returns></returns>
    public async Task<TransactionResponse?> GetTransactions(string hash)
    {
      string apiUrl = $"{GetClientUrl}txs/{hash}/utxos";
      return await HttpGet<TransactionResponse>(apiUrl);
    }

    /// <summary>
    /// Get Specific Asset
    /// </summary>
    /// <param name="hash">Specific Asset Hash</param>
    /// <returns></returns>
    public async Task<AssetResponse?> GetSpecificAsset(string hash)
    {
      string apiUrl = $"{GetClientUrl}assets/{hash}";
      return await HttpGet<AssetResponse>(apiUrl);
    }
  }
}
