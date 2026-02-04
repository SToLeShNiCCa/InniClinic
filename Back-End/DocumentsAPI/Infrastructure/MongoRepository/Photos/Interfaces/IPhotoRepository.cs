using Domain.Models;

namespace Infrastructure.MongoRepository.Photos.Interfaces
{
    public interface IPhotoRepository
    {
        Task<Photo?> GetByIdAsync(string id, CancellationToken token);
        Task CreateAsync(Photo photo, CancellationToken token);
        Task DeleteAsync (string id, CancellationToken token);
    }
}
