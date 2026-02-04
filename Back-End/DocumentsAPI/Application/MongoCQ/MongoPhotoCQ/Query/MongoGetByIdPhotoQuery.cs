using Application.DTO;
using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Query
{
    public record MongoGetByIdPhotoQuery(string Id) : IRequest<PhotoDTO>;
}
