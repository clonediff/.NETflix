namespace DotNetflixAdminAPI.Services;

public class FIleService : IFileService
{
    private readonly HttpClient _httpClient;

    public FIleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddFilesAsync(int movieId, IEnumerable<IFormFile> files, List<string> fileNames)
    {
        var content = files
            .Aggregate((Content: new MultipartFormDataContent(), Index: 0), (acc, cur) => 
            {
                acc.Content.Add(new StreamContent(cur.OpenReadStream()), "files", fileNames[acc.Index]);
                acc.Index++;
                return acc;
            }).Content;

        await _httpClient.PostAsync($"/api/files/{movieId}", content);
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