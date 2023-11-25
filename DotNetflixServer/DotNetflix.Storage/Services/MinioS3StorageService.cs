using System.IO;
using System.Threading.Tasks;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace DotNetflix.Storage.Services;

public class MinioS3StorageService : IS3StorageService
{
    private readonly IMinioClient _minioClient;

    public MinioS3StorageService(IMinioClient minioClient)
    {
        _minioClient = minioClient;
    }

    public async Task CreateBucketAsync(string bucketIdentifier)
    {
        var args = new MakeBucketArgs()
            .WithBucket(bucketIdentifier);

        await _minioClient.MakeBucketAsync(args);
    }

    public async Task RemoveBucketAsync(string bucketIdentifier)
    {
        var args = new RemoveBucketArgs()
            .WithBucket(bucketIdentifier);

        await _minioClient.RemoveBucketAsync(args);
    }

    public async Task<bool> BucketExistAsync(string bucketIdentifier)
    {
        var args = new BucketExistsArgs()
            .WithBucket(bucketIdentifier);

        return await _minioClient.BucketExistsAsync(args);
    }

    public async Task PutFileInBucketAsync(Stream fileStream, string fileIdentifier, string bucketIdentifier)
    {
        var args = new PutObjectArgs()
            .WithBucket(bucketIdentifier)
            .WithStreamData(fileStream)
            .WithObject(fileIdentifier)
            .WithObjectSize(fileStream.Length);

        await _minioClient.PutObjectAsync(args);
    }

    public async Task RemoveFileFromBucketAsync(string fileIdentifier, string bucketIdentifier)
    {
        var args = new RemoveObjectArgs()
            .WithBucket(bucketIdentifier)
            .WithObject(fileIdentifier);

        await _minioClient.RemoveObjectAsync(args);
    }

    public async Task<Stream?> GetFileFromBucketAsync(string fileIdentifier, string bucketIdentifier)
    {
        var response = new MemoryStream();
        var args = new GetObjectArgs()
            .WithBucket(bucketIdentifier)
            .WithObject(fileIdentifier)
            .WithCallbackStream(stream => stream.CopyTo(response));

        try
        {
            await _minioClient.GetObjectAsync(args);
        }
        catch (ObjectNotFoundException)
        {
            return null;
        }
        catch (BucketNotFoundException)
        {
            return null;
        }

        response.Position = 0;
        return response;
    }
}