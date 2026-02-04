using MediatR;

namespace Application.MongoCQ.MongoPhotoCQ.Command
{
    public record MongoCreatePhotoCommand(string Url) : IRequest<string>;
}
