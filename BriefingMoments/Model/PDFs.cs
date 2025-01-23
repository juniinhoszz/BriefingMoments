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

            //
            PdfBrush brush = PdfBrushes.Black;
            PdfBrush redBrush = PdfBrushes.Red;

            // Define dimensões da página
            float pageWidth = page.GetClientSize().Width;

            // **Cabeçalho Vermelho**
            graphics.DrawRectangle(redBrush, new Syncfusion.Drawing.RectangleF(0, 0, pageWidth, 50));
            graphics.DrawString("Briefing Moment's Eventos", Title, PdfBrushes.White, new Syncfusion.Drawing.PointF(10, 15));


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

            //string img = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "vermelho4.png");
            //// **Marca d'Água (Foto no canto inferior direito)**
            //if (File.Exists(img))
            //{
            //    Stream imageStream = new FileStream(img, FileMode.Open, FileAccess.Read);

            //    PdfBitmap marcaDagua = new PdfBitmap(imageStream);

            //    // Ajusta o tamanho e a posição da marca d'água
            //    float marcaDaguaWidth = 150; // Largura da imagem
            //    float marcaDaguaHeight = 150; // Altura da imagem
            //    float xPosition = pageWidth - marcaDaguaWidth - 10; // Canto inferior direito
            //    float yPosition = page.GetClientSize().Height - marcaDaguaHeight - 10;

            //    graphics.DrawImage(marcaDagua, new Syncfusion.Drawing.RectangleF(xPosition, yPosition, marcaDaguaWidth, marcaDaguaHeight));
            //}
            //else
            //{
            //    throw new FileNotFoundException("Imagem da marca d'água não encontrada.");
            //}

            // Salva o PDF no caminho especificado
            using FileStream fs = new FileStream(caminho, FileMode.Create, FileAccess.Write);
            document.Save(fs);
        }

    }
}
