using Azure.Storage.Blobs;
using Infrastructure.BLOBRepository.Interface;

namespace Infrastructure.BLOBRepository.Implementation
{
    public class BlobPhotoRepository(BlobServiceClient blobServiceClient) : IBlobRepository
    {
        private const string DocumentContainerName = "documents";
        private const string PhotoContainerName = "photoes";

        public BlobClient AddDocumentBlobClient(Guid fileId)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(DocumentContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            return blobClient;
        }

        public BlobClient AddPhotoBlobClient(Guid fileId)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(PhotoContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(fileId.ToString());

            return blobClient;
        }
    }
}
