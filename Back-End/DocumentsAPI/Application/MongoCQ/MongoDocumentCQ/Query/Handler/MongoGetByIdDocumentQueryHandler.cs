using Application.DTO;
using Infrastructure.MongoRepository.Documents.Interface;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Query.Handler
{
    public class MongoGetByIdDocumentQueryHandler(IDocumentRepository _repository)
        : IRequestHandler<MongoGetByIdDocumentQuery, DocumentDTO>
    {
        public async Task<DocumentDTO> Handle(MongoGetByIdDocumentQuery request, CancellationToken token)
        {
            var result = await _repository.GetByResultIdAsync(request.Id, token);

            return result.Adapt<DocumentDTO>();
        }
    }
}
