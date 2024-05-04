using System.Text.Json.Serialization;

namespace NftScanner.Wrapper.Entity.BlockFrost
{
  /// <summary>
  /// Transaction input
  /// </summary>
  public class TransactionInput
  {
    /// <summary>
    /// Input address
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Amount
    /// </summary>
    [JsonPropertyName("amount")]
    public TransactionAmount[] Amount { get; set; } = default!;

    /// <summary>
    /// Hash of the UTXO transaction
    /// </summary>
    [JsonPropertyName("tx_hash")]
    public string TxHash { get; set; } = string.Empty;

    /// <summary>
    /// UTXO index in the transaction
    /// </summary>
    [JsonPropertyName("output_index")]
    public long OutputIndex { get; set; } = default;

    /// <summary>
    /// The hash of the transaction output datum
    /// </summary>
    [JsonPropertyName("data_hash")]
    public string? DataHash { get; set; }

    /// <summary>
    /// CBOR encoded inline datum 
    /// </summary>
    [JsonPropertyName("inline_datum")]
    public string? InlineDatum { get; set; }

    /// <summary>
    /// The hash of the reference script of the input
    /// </summary>
    [JsonPropertyName("reference_script_hash")]
    public string? ReferenceScriptHash { get; set; }

    /// <summary>
    /// Whether the input is a collateral consumed on script validation failure
    /// </summary>
    [JsonPropertyName("collateral")]
    public bool Collateral { get; set; } = false;

    /// <summary>
    /// Whether the input is a reference transaction input
    /// </summary>
    [JsonPropertyName("reference")]
    public bool Reference { get; set; } = false;
  }
}
