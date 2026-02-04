using Application.DTO.ResultDTO;
using MediatR;

namespace Application.MongoCQ.MongoResultCQ.Command
{
    public record class CreateMongoResultCommand(CreateResultDTO ResultDTO) : IRequest<string>;
}
