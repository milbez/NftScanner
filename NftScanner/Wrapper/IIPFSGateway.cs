namespace NftScanner.Wrapper
{
  /// <summary>
  /// Interface to IPFS Gateway
  /// </summary>
  internal interface IIPFSGateway
  {
    /// <summary>
    /// Get Image
    /// </summary>
    /// <param name="hash">Image hash</param>
    /// <returns></returns>
    Task<byte[]?> GetImage(string hash);
  }
}
