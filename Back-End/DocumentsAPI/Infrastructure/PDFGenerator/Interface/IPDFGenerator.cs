using Domain.Models;

namespace Infrastructure.PDFGenerator.Interface
{
    public interface IPDFGenerator
    {
        byte[] GenerateResultsPdf(Result result);
    }
}
