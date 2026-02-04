using Application.BlobCQ.BlobDocumentCQ.Command;
using Domain.Models;
using Infrastructure.PDFGenerator.Interface;
using Mapster;
using MediatR;

namespace Application.PDFGenerationCQ.Handler
{
    public class PDFResultGeneratorCommandHandler : IRequestHandler<PDFGenerationCommand, string>
    {
        private readonly IPDFGenerator _pdfGenerator;
        private readonly IMediator _mediator;
        public PDFResultGeneratorCommandHandler(IPDFGenerator pdfGenerator, IMediator mediator)
        {
            _pdfGenerator = pdfGenerator;
            _mediator = mediator;
        }

        public async Task<string> Handle(PDFGenerationCommand request, CancellationToken cancellationToken)
        {
            var result = request.Result.Adapt<Result>();
            var pdfBytes = await Task.Run(() => _pdfGenerator.GenerateResultsPdf(result));

            var command = new AzureUploadDocumentCommand(pdfBytes, "application/pdf");
            var url =  await _mediator.Send(command, cancellationToken);

            return url;
        }
    }
}
