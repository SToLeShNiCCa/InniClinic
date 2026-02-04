using Application.DTO.ResultDTO;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command
{
    public record class UpdateMongoResultCommand(string Id, UpdateResultDTO UpdatedResultDTO) : IRequest<ReadResultDTO>;
}
