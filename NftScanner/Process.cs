using NftScanner.Wrapper;
using NftScanner.Wrapper.Entity.BlockFrost;

namespace NftScanner
{
  /// <summary>
  /// Application main process
  /// </summary>
  internal class Process
  {
    private readonly IBlockFrost _blockFrostClient;
    private readonly IIPFSGateway _ipfsClient;
    private string TransactionRootDirectory { get; } = "Transactions";

    public Process(IBlockFrost blockFrostClient
      , IIPFSGateway ipfsClient) 
    {
      _blockFrostClient = blockFrostClient;
      _ipfsClient = ipfsClient;
    }

    /// <summary>
    /// Start Main Process
    /// </summary>
    /// <param name="args">Application Arguments</param>
    /// <returns></returns>
    public async Task Run(string[] args)
    {
      foreach (var arg in args)
      {
        Console.WriteLine($"Argument: {arg}");

        //Create Directory for Transaction
        var dirName = $"{TransactionRootDirectory}//{arg}";
        Directory.CreateDirectory(dirName);

        //Get Transaction
        await GetTransactions(dirName, arg);
      }
    }

    /// <summary>
    /// Get Transaction
    /// </summary>
    /// <param name="dirName">Transaction Directory Name</param>
    /// <param name="hash">Transaction Hash</param>
    /// <returns></returns>
    public async Task GetTransactions(string dirName, string hash)
    {
      //Get Transaction
      var transactions = await _blockFrostClient.GetTransactions(hash);

      //Create Transaction Specific Assets List
      var assetList = new List<TransactionAmount>();
      transactions?.Inputs.ToList()
        .ForEach(x => x?.Amount?.Where(x => x.Quantity == "1" && x.Unit != "lovelace")
        .ToList().ForEach(p => assetList.Add(p)));

      //Get All Specific Assets
      await GetAssets(dirName, assetList.ToArray());
    }

    /// <summary>
    /// Get All Specific Assets
    /// </summary>
    /// <param name="dirName">Transaction Directory Name</param>
    /// <param name="model">List of Specific Assets</param>
    /// <returns></returns>
    private async Task GetAssets(string dirName, TransactionAmount[] model)
    {
      var imageList = new List<AssetOnchaineMetadata>();

      //Get All Specific Assets
      foreach (var unitItem in model)
      {
        //Get Specific Assets
        var hash = unitItem.Unit;
        var assets = await _blockFrostClient.GetSpecificAsset(hash);

        //Create Images List
        if (!string.IsNullOrWhiteSpace(assets?.OnchainMetadata?.Image))
          imageList.Add(assets.OnchainMetadata);
      }

      //Get All Images
      await GetImages(dirName, imageList.ToArray());
    }

    /// <summary>
    /// Get All Images
    /// </summary>
    /// <param name="dirName">Transaction Directory Name</param>
    /// <param name="model">List of Image URL</param>
    /// <returns></returns>
    private async Task GetImages(string dirName, AssetOnchaineMetadata[] model)
    {
      foreach (var metadataItem in model)
      {
        //Get Image Hash
        var imageItem = metadataItem.Image;
        if (imageItem == null) continue;
        var imageHash = imageItem.Replace("ipfs://", "");

        //Get Image
        var stream = await _ipfsClient.GetImage(imageHash);
        if (stream == null)
          continue;

        //Find Image Extension
        var mediaType = metadataItem.MediaType?.Replace("image/", "");
        mediaType = mediaType?.Replace("+xml", "");

        //Save Image
        string path = Path.Combine(dirName, $"{metadataItem.Name}.{mediaType}");
        using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
        {
          outputFileStream.Write(stream);
          outputFileStream.Close();
          outputFileStream.Dispose();
        }
      }
    }
  }
}
