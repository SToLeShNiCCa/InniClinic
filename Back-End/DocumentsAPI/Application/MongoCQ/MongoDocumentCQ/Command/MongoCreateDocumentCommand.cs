using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Command
{
    public record class MongoCreateDocumentCommand(string Url, string ResultId) : IRequest;
}
