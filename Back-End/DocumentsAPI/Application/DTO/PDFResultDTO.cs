namespace Application.DTO
{
    public class PDFResultDTO
    {
        public byte[]? Content { get; set; }
        public string? FileName { get; set; }
        public string ContentType { get; set; } = "application/pdf";
    }
}
