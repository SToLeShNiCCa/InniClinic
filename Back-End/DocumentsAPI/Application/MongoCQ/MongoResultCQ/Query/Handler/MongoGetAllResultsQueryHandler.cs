using Application.DTO.ResultDTO;
using Infrastructure.MongoRepository.Results.Interfaces;
using Mapster;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Query.Handler
{
    public class MongoGetAllResultsQueryHandler(IResultRepository _repository)
        : IRequestHandler<MongoGetAllResultsQuery, IReadOnlyCollection<ReadResultDTO>>
    {
        public async Task<IReadOnlyCollection<ReadResultDTO>> Handle(MongoGetAllResultsQuery request, CancellationToken cancellationToken)
        {
            var collection =  await _repository.GetAllResult(request.PageInfo, cancellationToken);
            var result = collection.Data.Adapt<IReadOnlyCollection<ReadResultDTO>>();

            return result;
        }
    }
}
