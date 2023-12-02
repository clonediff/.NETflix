using System.IO;
using System.Threading.Tasks;
using Contracts.Shared;
using DotNetflix.Storage.Services;
using DotNetflix.Storage.Services.S3;
using MassTransit;

namespace DotNetflix.Storage.Consumers;

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