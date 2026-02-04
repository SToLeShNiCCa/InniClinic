using Application.Exceptions.MongoExceptions;
using Domain.Models;
using Infrastructure.MongoRepository.Photos.Interfaces;
using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Command.Handler
{
    public class MongoCreatePhotoCommandHandler(IPhotoRepository _photoRepository)
        : IRequestHandler<MongoCreatePhotoCommand, string>
    {
        public async Task<string> Handle(MongoCreatePhotoCommand request, CancellationToken token)
        {
            try
            {
                var photo = new Photo()
                {
                    Url = request.Url
                };
                await _photoRepository.CreateAsync(photo, token);

                return photo.Id;
            }
            catch (AddMongoDataException)
            {
                throw new AddMongoDataException("Failed to add photo data to MongoDB.");
            }
        }
    }
}
