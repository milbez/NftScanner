using System.Text.Json.Serialization;

namespace NftScanner.Wrapper.Entity.BlockFrost
{
  /// <summary>
  /// Response from Transaction Method
  /// </summary>
  public class TransactionResponse
  {
    /// <summary>
    /// Hash 
    /// </summary>
    [JsonPropertyName("hash")]
    public string Hash { get; set; } = string.Empty;

    /// <summary>
    /// Inputs
    /// </summary>
    [JsonPropertyName("inputs")]
    public TransactionInput[] Inputs { get; set; } = default!;

    /// <summary>
    /// Outputs
    /// </summary>
    [JsonPropertyName("outputs")]
    public TransactionOutput[] Oututs { get; set; } = default!;
  }
}
