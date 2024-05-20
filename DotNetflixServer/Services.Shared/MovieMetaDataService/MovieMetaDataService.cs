using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Configuration.Shared.Constants.HttpHeaderNames;

namespace Services.Shared.MovieMetaDataService;

public class MovieMetaDataService : IMovieMetaDataService
{
    private readonly HttpClient _httpClient;

    public MovieMetaDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<TMetaData>> GetMetaDataAsync<TMetaData>(int movieId, string metaDataType)
    {
        _httpClient.DefaultRequestHeaders.Remove(MetaDataTypeHeaderName);
        _httpClient.DefaultRequestHeaders.Add(MetaDataTypeHeaderName, metaDataType);

        var response = await _httpClient.GetAsync($"/api/metadata/{movieId}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<IEnumerable<TMetaData>>() ?? Enumerable.Empty<TMetaData>();
        }

        return Enumerable.Empty<TMetaData>();
    }

    public async Task UpdateMetaDataAsync<TMetaData>(int movieId, Guid metaDataId, string metaDataType, TMetaData metaData)
    {
        _httpClient.DefaultRequestHeaders.Remove(MetaDataTypeHeaderName);
        _httpClient.DefaultRequestHeaders.Add(MetaDataTypeHeaderName, metaDataType);

        await _httpClient.PutAsJsonAsync($"/api/metadata/{movieId}?id={metaDataId}", metaData, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }

    public async Task AddMetaDataAsync<TMetaData>(int movieId, string metaDataType, IEnumerable<TMetaData> metadata)
    {
        _httpClient.DefaultRequestHeaders.Remove(MetaDataTypeHeaderName);
        _httpClient.DefaultRequestHeaders.Add(MetaDataTypeHeaderName, metaDataType);
        
        await _httpClient.PostAsJsonAsync($"/api/metadata/{movieId}", metadata, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }

    public async Task DeleteMetaDataAsync(Guid metaDataId)
    {
        await _httpClient.DeleteAsync($"/api/metadata/{metaDataId}");
    }

    public async Task DeleteMovieMetaDataAsync(int movieId)
    {
        await _httpClient.DeleteAsync($"/api/metadata/{movieId}");
    }
}