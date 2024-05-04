using System.Text.Json.Serialization;

namespace NftScanner.Wrapper.Entity.BlockFrost
{
  /// <summary>
  /// Response from Specific Asset Method
  /// </summary>
  public class AssetResponse
  {
    /// <summary>
    /// Hex-encoded asset full name
    /// </summary>
    [JsonPropertyName("asset")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Policy ID of the asset
    /// </summary>
    [JsonPropertyName("policy_id")]
    public string PolicyId { get; set; } = string.Empty;

    /// <summary>
    /// Hex-encoded asset name of the asset
    /// </summary>
    [JsonPropertyName("asset_name")]
    public string? AssetName { get; set; }

    /// <summary>
    /// CIP14 based user-facing fingerprint
    /// </summary>
    [JsonPropertyName("fingerprint")]
    public string Fingerprint { get; set; } = string.Empty;

    /// <summary>
    /// Current asset quantity
    /// </summary>
    [JsonPropertyName("quantity")]
    public string Quantity { get; set; } = string.Empty;

    /// <summary>
    /// ID of the initial minting transaction
    /// </summary>
    [JsonPropertyName("initial_mint_tx_hash")]
    public string InitialMintTxHash { get; set; } = string.Empty;

    /// <summary>
    /// Count of mint and burn transactions
    /// </summary>
    [JsonPropertyName("mint_or_burn_count")]
    public long MintOrBurnCount { get; set; } = default;

    /// <summary>
    /// If on-chain metadata passes validation, we display the standard under which it is valid
    /// </summary>
    [JsonPropertyName("onchain_metadata")]
    public AssetOnchaineMetadata OnchainMetadata { get; set; } = default!;

    /// <summary>
    /// If on-chain metadata passes validation, we display the standard under which it is valid
    /// </summary>
    [JsonPropertyName("onchain_metadata_standard")]
    public string? OnchainMetadataStandard { get; set; }

    /// <summary>
    /// Arbitrary plutus data (CIP68).
    /// </summary>
    [JsonPropertyName("onchain_metadata_extra")]
    public string? OnchainMetadataExtra { get; set; }

    /// <summary>
    /// Off-chain metadata fetched from GitHub based on network. Mainnet:
    /// </summary>
    [JsonPropertyName("metadata")]
    public AssetMetadata Metadata { get; set; } = default!;
  }
}
