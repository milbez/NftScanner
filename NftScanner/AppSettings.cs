namespace NftScanner
{
  /// <summary>
  /// Application settings
  /// </summary>
  public sealed class AppSettings
  {
    /// <summary>
    /// Authentization Api Key to Block Frost Api
    /// </summary>
    public string BlockFrostApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Base Url to Block Frost Api
    /// </summary>
    public string BlockFrostBaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// Base Url to IPFS Gateway
    /// </summary>
    public string IPFSBaseUrl { get; set; } = string.Empty;
  }
}
