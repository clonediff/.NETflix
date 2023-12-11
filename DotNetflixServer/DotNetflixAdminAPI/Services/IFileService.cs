namespace DotNetflixAdminAPI.Services;

public interface IFileService
{
    Task AddFilesAsync(int movieId, IEnumerable<IFormFile> files, List<string> fileNames);

    Task DeleteFilesAsync(int movieId, IEnumerable<string> fileNames);

    Task DeleteAllMovieFilesAsync(int movieId);
}