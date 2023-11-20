namespace Contracts.Shared;

public record FileMessage(byte[] Bytes, string FileIdentifier, string BucketIdentifier);