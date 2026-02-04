using Azure.Storage.Blobs;

namespace Infrastructure.BLOBRepository.Interface
{
    public interface IBlobRepository
    {
        BlobClient AddPhotoBlobClient(Guid fileId);
        BlobClient AddDocumentBlobClient(Guid fileId);
    }
}
