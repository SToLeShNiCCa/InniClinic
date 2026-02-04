using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Command
{
    public record class MongoDeleteDocumentCommand(string DocumentId) : IRequest<Unit>;
}
