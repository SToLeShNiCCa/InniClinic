using Domain.Models;
using Infrastructure.MongoRepository.Results.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command.Handler
{
    public class CreateMongoResultCommandHandler(IResultRepository _repository)
        : IRequestHandler<CreateMongoResultCommand, string>
    {
        public async Task<string> Handle(CreateMongoResultCommand request, CancellationToken cancellationToken)
        {
            var result = request.ResultDTO.Adapt<Result>();
            await _repository.CreateAsync(result, cancellationToken);
            
            return result.Id;
        }
    }
}
