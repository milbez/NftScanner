namespace NftScanner.Wrapper
{
  /// <summary>
  /// Client to IPFS Gateway
  /// </summary>
  internal class IPFSGateway : BaseWrapper, IIPFSGateway
  {
    /// <summary>
    /// Client service URL
    /// </summary>
    protected override string GetClientUrl
    {
      get
      {
        return _settings.IPFSBaseUrl;
      }
    }

    public IPFSGateway(AppSettings settings, IHttpClientFactory httpClientFactory)
      : base(settings, httpClientFactory)
    {
    }

    /// <summary>
    /// Get Image
    /// </summary>
    /// <param name="hash">Image hash</param>
    /// <returns></returns>
    public async Task<byte[]?> GetImage(string hash)
    {
      string apiUrl = $"{GetClientUrl}ipfs/{hash}";
      return await HttpGet(apiUrl);
    }
  }
}
