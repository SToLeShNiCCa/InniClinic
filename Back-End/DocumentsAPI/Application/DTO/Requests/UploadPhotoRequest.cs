using Microsoft.AspNetCore.Http;

namespace Application.DTO.Requests
{
    public record UploadPhotoRequest(IFormFile File);
}
