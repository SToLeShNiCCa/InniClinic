using Application.DTO.ResultDTO;
using Domain.Models;
using Infrastructure.MongoRepository.Results.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command.Handler
{
    public class UpdateMongoResultCommandHandler(IResultRepository _repository) : IRequestHandler<UpdateMongoResultCommand, ReadResultDTO>
    {
        public async Task<ReadResultDTO> Handle(UpdateMongoResultCommand request, CancellationToken cancellationToken)
        {
            var updatedResult = request.UpdatedResultDTO.Adapt<Result>();
            await _repository.UpdateResult(request.Id, updatedResult, cancellationToken);

            var readResultDTO = updatedResult.Adapt<ReadResultDTO>();
            return readResultDTO;
        }
    }
}
