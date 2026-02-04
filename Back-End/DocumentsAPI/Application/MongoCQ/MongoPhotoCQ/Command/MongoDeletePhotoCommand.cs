using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Command
{
    public record MongoDeletePhotoCommand(string Id) : IRequest<Unit>;
}
