using Infrastructure.MongoRepository.Results.Interfaces;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command.Handler
{
    public class DeleteMongoResultCommandHandler(IResultRepository _repository)
        : IRequestHandler<DeleteMongoResultCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteMongoResultCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
