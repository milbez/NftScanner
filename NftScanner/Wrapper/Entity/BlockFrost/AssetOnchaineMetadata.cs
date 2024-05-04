using System.Text.Json.Serialization;

namespace NftScanner.Wrapper.Entity.BlockFrost
{
  /// <summary>
  /// Off-chain metadata fetched from GitHub based on network. Mainnet:
  /// </summary>
  public class AssetOnchaineMetadata
  {
    /// <summary>
    /// Image name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Image hash
    /// </summary>
    [JsonPropertyName("image")]
    public string? Image { get; set; }

    /// <summary>
    /// Media Type
    /// </summary>
    [JsonPropertyName("mediaType")]
    public string? MediaType { get; set; }
  }
}
