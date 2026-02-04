using Application.DTO;
using Application.DTO.ResultDTO;
using Domain.Models;
using MediatR;

namespace Application.PDFGenerationCQ
{
    public record class PDFGenerationCommand(CreateResultDTO Result) : IRequest<string>;
}
