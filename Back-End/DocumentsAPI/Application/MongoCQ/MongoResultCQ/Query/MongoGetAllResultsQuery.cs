using Application.DTO.ResultDTO;
using Infrastructure.PageSettings;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Query
{
    public record class MongoGetAllResultsQuery(PageInfo PageInfo):IRequest<IReadOnlyCollection<ReadResultDTO>>;
}
