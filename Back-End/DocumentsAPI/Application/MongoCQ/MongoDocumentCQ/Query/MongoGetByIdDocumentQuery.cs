using Application.DTO;
using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Query
{
    public record class MongoGetByIdDocumentQuery(string Id) : IRequest<DocumentDTO>;
}
