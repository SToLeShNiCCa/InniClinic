using Infrastructure.MongoRepository.Documents.Interface;
using MediatR;

namespace Application.MongoCQ.MongoDocumentCQ.Command.Handler
{
    public class MongoDeleteDocumentCommandHandler(IDocumentRepository _repository)
        : IRequestHandler<MongoDeleteDocumentCommand, Unit>
    {
        public async Task<Unit> Handle(MongoDeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.DocumentId, cancellationToken);
            return Unit.Value;
        }
    }
}
