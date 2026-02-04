using Infrastructure.BLOBRepository.Interface;
using MediatR;

namespace Application.BlobCQ.BlobPhotoCQ.Command.Handler
{
    public class AzureDeletePhotoCommandHandler(IBlobRepository _repository)
        : IRequestHandler<AzureDeletePhotoCommand, Unit>
    {
        public async Task<Unit> Handle(AzureDeletePhotoCommand request, CancellationToken token)
        {
            var blobClient = _repository.AddPhotoBlobClient(request.fileId);

            await blobClient.DeleteIfExistsAsync(cancellationToken: token);

            return Unit.Value;
        }
    }
}
