using Application.DTO.ResultDTO;
using Mapster;
using MediatR;

namespace Application.Coordinator.Document.Handler
{
    public class UpdateDocumentsCoordinatorCommandHandler(IMediator _mediator)
        : IRequestHandler<UpdateDocumentCoordinatorCommand, string>
    {
        public async Task<string> Handle(UpdateDocumentCoordinatorCommand request, CancellationToken cancellationToken)
        {
            var deleteCommand = new DeleteDocumentCoordinatorCommand(request.Id);//сделать ебаный поиск документа по айди результата это поле есть в обеих таблицах по нему норм искать
            await _mediator.Send(deleteCommand);

            var createCommand = new CreateDocumentCoordinatorCommand(request.UpdatedResultDTO.Adapt<CreateResultDTO>());
            var newDocumentUrl = await _mediator.Send(createCommand);

            return newDocumentUrl;
        }
    }
}
