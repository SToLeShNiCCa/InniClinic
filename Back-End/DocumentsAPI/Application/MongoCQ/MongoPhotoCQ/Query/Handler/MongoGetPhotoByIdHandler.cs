using Application.DTO;
using Infrastructure.MongoRepository.Photos.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Query.Handler
{
    public class MongoGetPhotoByIdHandler(IPhotoRepository _repository)
        : IRequestHandler<MongoGetByIdPhotoQuery, PhotoDTO>
    {
        public async Task<PhotoDTO> Handle(MongoGetByIdPhotoQuery request, CancellationToken token)
        {
            var photo = await _repository.GetByIdAsync(request.Id, token);
            if (photo == null) throw new Exception("photo is not found");//Result

            return photo.Adapt<PhotoDTO>(); ;
        }
    }
}
