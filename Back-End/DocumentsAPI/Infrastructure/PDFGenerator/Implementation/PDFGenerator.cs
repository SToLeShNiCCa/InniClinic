using Domain.Models;
using Infrastructure.PDFGenerator.Interface;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Document = QuestPDF.Fluent.Document;

namespace Infrastructure.PDFGenerator.Implementation
{
    public class PDFGenerator : IPDFGenerator
    {
        public PDFGenerator()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public byte[] GenerateResultsPdf(Result result)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .PaddingBottom(50)
                        .AlignCenter()
                        .Text("Медицинский отчёт.")
                        .SemiBold().FontSize(24).FontColor(Colors.Black);

                    page.Content()
                        .Column(column =>
                        {
                            column.Item()
                                .Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(2);
                                        columns.RelativeColumn(3);
                                    });

                                    table.Cell().Element(CellStyle).Text("Жалобы");
                                    table.Cell().Element(CellStyle).Text(result.Complaints);

                                    table.Cell().Element(CellStyle).Text("Заключение");
                                    table.Cell().Element(CellStyle).Text(result.Conclusion);

                                    table.Cell().Element(CellStyle).Text("Рекомендации");
                                    table.Cell().Element(CellStyle).Text(result.Recommendations);

                                    static IContainer CellStyle(IContainer container)
                                    {
                                        return container
                                            .BorderBottom(1)
                                            .BorderColor(Colors.Grey.Lighten2)
                                            .PaddingVertical(8);
                                    }
                                });

                            column.Item().Height(2, Unit.Centimetre);

                            column.Item()
                                .Row(row =>
                                {
                                    row.RelativeItem()
                                        .Column(signatureColumn =>
                                        {
                                            signatureColumn.Item().PaddingTop(25).Text("Врач : ");
                                            signatureColumn.Item().PaddingTop(1).LineHorizontal(1).LineColor(Colors.Black);
                                            signatureColumn.Item().PaddingTop(25).Text("Подпись : ");
                                            signatureColumn.Item().PaddingTop(1).LineHorizontal(1).LineColor(Colors.Black);
                                        });

                                    row.RelativeItem()
                                        .AlignCenter()
                                        .Element(CreateMedicalStamp);

                                    row.RelativeItem()
                                        .AlignRight()
                                        .Column(dateColumn =>
                                        {
                                            dateColumn.Item().PaddingTop(25).Text("Дата").SemiBold().FontSize(11);
                                            dateColumn.Item().PaddingTop(5).LineHorizontal(1).LineColor(Colors.Black);
                                            dateColumn.Item().PaddingTop(5).Text(DateTime.Now.ToString("(dd.MM.yyyy)"));
                                        });
                                });
                        });
                });
            });

            return document.GeneratePdf();
        }

        private void CreateMedicalStamp(IContainer container)
        {
            container
                .Width(130)
                .Height(100)
                .Border(2)
                .BorderColor(Colors.Blue.Medium)
                .Padding(5)
                .Background(Colors.White)
                .AlignCenter()
                .AlignMiddle()
                .Column(column =>
                {
                    column.Item().AlignCenter().Text("ГОСУДАРСТВЕННОЕ").Bold().FontColor(Colors.Blue.Darken1).FontSize(8);
                    column.Item().AlignCenter().Text("МЕДИЦИНСКОЕ").Bold().FontColor(Colors.Blue.Darken1).FontSize(8);
                    column.Item().AlignCenter().Text("УЧРЕЖДЕНИЕ РБ").Bold().FontColor(Colors.Blue.Darken1).FontSize(8);
                    column.Item().AlignCenter().Text("\"ГОРОДСКАЯ ПОЛИКЛИНИКА\"").FontColor(Colors.Black).FontSize(7);
                    column.Item().AlignCenter().Text("№ 2").FontColor(Colors.Black).FontSize(7);
                    column.Item().AlignCenter().Text("г. Полоцк").FontColor(Colors.Black).FontSize(6);
                });
        }
    }
}