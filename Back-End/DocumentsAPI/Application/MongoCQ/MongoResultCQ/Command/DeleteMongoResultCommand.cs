using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command
{
    public record class DeleteMongoResultCommand(string Id):IRequest<Unit>;
}
