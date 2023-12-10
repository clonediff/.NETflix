using static Configuration.Shared.Constants.HttpClientNames;

namespace DotNetflixAdminAPI.Services;

public class FIleService : IFileService
{
    private readonly HttpClient _httpClient;

    public FIleService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(FileHttpClientName);
    }

    public async Task AddFilesAsync(int movieId, IEnumerable<IFormFile> files, List<string> fileNames)
    {
        await Task.WhenAll(files
            .Select((f, i) =>
            {
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(f.OpenReadStream()), "file", fileNames[i]);
                return _httpClient.PostAsync($"/api/files/{movieId}/{fileNames[i]}", content);
            }));
    }

    public async Task DeleteFilesAsync(int movieId, IEnumerable<string> fileNames)
    {
        foreach (var fileName in fileNames)
        {
            await _httpClient.DeleteAsync($"/api/files/{movieId}/{fileName}");
        }
    }

    public async Task DeleteAllMovieFilesAsync(int movieId)
    {
        await _httpClient.DeleteAsync($"/api/files/{movieId}");
    }
}