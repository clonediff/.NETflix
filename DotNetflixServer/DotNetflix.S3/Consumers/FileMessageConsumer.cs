using Contracts.Shared;
using DotNetflix.S3.Services;
using MassTransit;

namespace DotNetflix.S3.Consumers;

public class FileMessageConsumer : IConsumer<FileMessage>
{
    private readonly IS3StorageService _storageService;

    public FileMessageConsumer(IS3StorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task Consume(ConsumeContext<FileMessage> context)
    {
        context.Message.Deconstruct(out var buffer, out var fileIdentifier, out var bucketIdentifier);
        
        var stream = new MemoryStream(buffer);
        var bucketExists = await _storageService.BucketExistAsync(bucketIdentifier);

        if (!bucketExists)
        {
            await _storageService.CreateBucketAsync(bucketIdentifier);
        }
            
        await _storageService.PutFileInBucketAsync(stream, fileIdentifier, bucketIdentifier);
    }
}