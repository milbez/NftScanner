using System.Text.Json.Serialization;

namespace NftScanner.Wrapper.Entity.BlockFrost
{
  /// <summary>
  /// Transaction Amount
  /// </summary>
  public class TransactionAmount
  {
    /// <summary>
    /// The unit of the value
    /// </summary>
    [JsonPropertyName("unit")]
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the unit
    /// </summary>
    [JsonPropertyName("quantity")]
    public string Quantity { get; set; } = string.Empty;
  }
}
