using System.Net.Http.Json;
using System.Text.Json;
using System.Xml.Serialization;

namespace NftScanner.Wrapper
{
  /// <summary>
  /// Client Base Wrapper
  /// </summary>
  internal class BaseWrapper
  {
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly AppSettings _settings;

    /// <summary>
    /// Client service URL
    /// </summary>
    protected virtual string GetClientUrl
    {
      get
      {
        return _settings.BlockFrostBaseUrl;
      }
    }

    public BaseWrapper(AppSettings settings, IHttpClientFactory httpClientFactory)
    {
      _settings = settings;
      _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Create HTTP Client
    /// </summary>
    /// <returns></returns>
    protected virtual HttpClient GetHttpClient(string? uri)
    {
      var httpClient = _httpClientFactory.CreateClient();
//      ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Add("project_id", _settings.BlockFrostApiKey);
      if (uri != null)
      {
        httpClient.BaseAddress = new Uri(uri);
      }
      return httpClient;
    }

    /// <summary>
    /// Call HTTP Get method 
    /// </summary>
    /// <param name="apiUrl">URL of Get method</param>
    /// <returns></returns>
    protected async Task<byte[]?> HttpGet(string apiUrl)
    {
      var client = GetHttpClient(null);
      try
      {
        var response = await client.GetAsync($"{apiUrl}");
        var bytes = await response.Content.ReadAsByteArrayAsync();
        return bytes;
      }
      catch (Exception ex)
      {
        var msg = ex.Message;
      }
      return default;
    }

    /// <summary>
    /// Call HTTP Get method 
    /// </summary>
    /// <typeparam name="T">Return object type</typeparam>
    /// <param name="apiUrl">URL of Get method</param>
    /// <returns></returns>
    protected virtual async Task<T?> HttpGet<T>(string apiUrl)
    {
      var client = GetHttpClient(null);
      try
      {
        var response = await client.GetAsync($"{apiUrl}");
        return await ConvertToEntity<T>(response);
      }
      catch (Exception ex)
      {
        var msg = ex.Message;
      }
      return default;
    }

    /// <summary>
    /// Call HTTP Post method 
    /// </summary>
    /// <typeparam name="T">Return object type</typeparam>
    /// <param name="apiUrl">URL of Post method</param>
    /// <param name="request">Object requested by Post method</param>
    /// <returns></returns>
    protected async Task<T?> HttpPost<T>(string apiUrl, object request)
    {
      var client = GetHttpClient(null);
      var response = await client.PostAsJsonAsync($"{GetClientUrl}/{apiUrl}", request);
      return await ConvertToEntity<T>(response);
    }

    /// <summary>
    /// Convert service response to requiered object type
    /// </summary>
    /// <typeparam name="T">Required response object type</typeparam>
    /// <param name="response">Service response</param>
    /// <returns></returns>
    protected async Task<T?> ConvertToEntity<T>(HttpResponseMessage? response)
    {
      if (response == null)
        return default;

      //using var responseStream = await response.Content.ReadAsStreamAsync();
      //StreamReader reader = new StreamReader(responseStream);
      //var response2 = await reader.ReadToEndAsync();

      if (response.IsSuccessStatusCode)
      {
        using var okResponseStream = await response.Content.ReadAsStreamAsync();

        try
        {
          T? model = await JsonSerializer.DeserializeAsync<T>(okResponseStream);
          return model;
        }
        catch (Exception ex)
        {
          var msg = ex.Message;
        }
      }

      return default;
    }
  }
}
