using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace BriefingMoments.Model
{
    class PDFs
    {
        public async Task GerarPdf(string caminho, DadosModel dados)
        {
            // Cria um documento PDF
            using PdfDocument document = new PdfDocument();

            // Adiciona uma página ao documento
            PdfPage page = document.Pages.Add();

            // Obtém as dimensões da página
            PdfGraphics graphics = page.Graphics;
            float yOffset = 30; // Espaço inicial no topo da página

            // Define a fonte para o texto
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            PdfFont Title = new PdfStandardFont(PdfFontFamily.TimesRoman, 18);
            

            graphics.DrawString("Briefing Moment's Eventos", Title, PdfBrushes.Red, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 35;
            // Escreve os dados do modelo no PDF
            graphics.DrawString($"Nome da Instituição: {dados.Nome}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Tipo de Colégio: {dados.TipoColegio}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Quantidade de Turmas: {dados.QntTurmas}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Quantidade de Alunos(Total): {dados.QntAlunos}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Valor de Repasse: R$ {dados.ValorRepasse:F2}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Tipo de Produção: {dados.Producao}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Data de Colação de Grau: {dados.DataCol:dd/MM/yyyy}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Data do Baile de Formatura: {dados.DataBaile:dd/MM/yyyy}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString($"Observações:", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            graphics.DrawString(dados.Obs, font, PdfBrushes.Black, new Syncfusion.Drawing.RectangleF(10, yOffset, page.GetClientSize().Width - 20, 100));
            yOffset += 120;

            graphics.DrawString($"Realizado por: {dados.NomeOperador}", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(10, yOffset));
            yOffset += 25;

            //graphics.DrawImage

            // Salva o PDF no caminho especificado
            using FileStream fs = new FileStream(caminho, FileMode.Create, FileAccess.Write);
            document.Save(fs);
        }

    }
}
