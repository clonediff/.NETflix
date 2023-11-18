using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Services.Infrastructure.S3;

public class MinioS3Storage : IS3Storage
{
    private readonly IMinioClient _minioClient;

    public MinioS3Storage(IMinioClient minioClient)
    {
        _minioClient = minioClient;
    }
    
    public async Task CreateBucket(string bucketIdentifier)
    {
        var args = new MakeBucketArgs()
            .WithBucket(bucketIdentifier);

        await _minioClient.MakeBucketAsync(args);
    }   

    public async Task RemoveBucket(string bucketIdentifier)
    {
        var args = new RemoveBucketArgs()
            .WithBucket(bucketIdentifier);

        await _minioClient.RemoveBucketAsync(args);
    }

    public async Task<bool> BucketExist(string bucketIdentifier)
    {
        var args = new BucketExistsArgs()
            .WithBucket(bucketIdentifier);

        return await _minioClient.BucketExistsAsync(args);
    }

    public async Task PutFileInBucket(Stream fileStream, string fileIdentifier, string bucketIdentifier)
    {
        var args = new PutObjectArgs()
            .WithBucket(bucketIdentifier)
            .WithStreamData(fileStream)
            .WithObject(fileIdentifier)
            .WithObjectSize(fileStream.Length);

        await _minioClient.PutObjectAsync(args);
    }

    public async Task RemoveFileFromBucket(string fileIdentifier, string bucketIdentifier)
    {
        var args = new RemoveObjectArgs()
            .WithBucket(bucketIdentifier)
            .WithObject(fileIdentifier);

        await _minioClient.RemoveObjectAsync(args);
    }

    public async Task<Stream?> GetFileFromBucket(string fileIdentifier, string bucketIdentifier)
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

        return response;
    }
}