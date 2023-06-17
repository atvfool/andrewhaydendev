namespace andrewhaydendev.Classes
{
    using IronPdf;
    public class PDFGenerator
    {
        public static void Generator()
        {
            var html = @"<h1>Hello World</h1>";
            var Renderer = new IronPdf.ChromePdfRenderer();
            using var cover = Renderer.RenderHtmlAsPdf("<h1>This is a cover page</h1>");

            Renderer.RenderingOptions.FirstPageNumber = 1;
            Renderer.RenderingOptions.HtmlFooter = new IronPdf.HtmlHeaderFooter()
            {
                MaxHeight = 15,
                HtmlFragment = "<center><i>{page} of {total-pages}</i></center>",
                DrawDividerLine = true
            };

            using PdfDocument Pdf = Renderer.RenderHtmlAsPdf(html);
            using PdfDocument merge = IronPdf.PdfDocument.Merge(cover, Pdf);

            merge.SaveAs("HelloWorld.pdf");

        }
    }
}
