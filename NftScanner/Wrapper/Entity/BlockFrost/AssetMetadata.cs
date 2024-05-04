using System.Text.Json.Serialization;

namespace NftScanner.Wrapper.Entity.BlockFrost
{
  /// <summary>
  /// Off-chain metadata fetched from GitHub based on network. Mainnet:
  /// </summary>
  public class AssetMetadata
  {
    /// <summary>
    /// Asset name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Asset description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Ticker 
    /// </summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    /// <summary>
    /// Url
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Base64 encoded logo of the asset
    /// </summary>
    [JsonPropertyName("logo")]
    public string? Logo { get; set; }

    /// <summary>
    /// Number of decimal places of the asset unit
    /// </summary>
    [JsonPropertyName("decimals")]
    public long? Decimals { get; set; } = default;
  }
}
