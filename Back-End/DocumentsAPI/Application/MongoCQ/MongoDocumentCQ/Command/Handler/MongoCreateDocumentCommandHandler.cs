using Domain.Models;
using Infrastructure.MongoRepository.Documents.Interface;
using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Command.Handler
{
    public class MongoCreateDocumentCommandHandler(IDocumentRepository _repository)
        : IRequestHandler<MongoCreateDocumentCommand>
    {
        public async Task Handle(MongoCreateDocumentCommand request, CancellationToken token)
        {
            var document = new Document
            {
                ResultId = request.ResultId,
                Url = request.Url
            };
            await _repository.CreateAsync(document, token);
        }
    }
}
