using BriefingMoments.Model;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Data;
using Microsoft.Maui.Storage;


namespace BriefingMoments.View;

public partial class NewBriefing : ContentPage
{
    App PropriedadesApp;
    public NewBriefing()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_tipo_colegio.ItemsSource = PropriedadesApp.tipo_colegio;
        pck_tipo_producao.ItemsSource = PropriedadesApp.tipo_prod;

        data_col.MinimumDate = DateTime.Now;
        data_baile.MinimumDate = DateTime.Now;
    }

    private void back_Clicked(object sender, EventArgs e)
    {
        //string valorSelecionado = pck_tipo_colegio.SelectedItem.ToString();
        //DisplayAlert("Valor Selecionado", $"Você escolheu: {valorSelecionado}", "OK");

        Navigation.PopAsync();
    }

    private async void finalizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            DadosModel Brf = new DadosModel
            {
                Nome = nome_inst.Text,
                TipoColegio = pck_tipo_colegio.SelectedItem.ToString(),
                QntTurmas = Convert.ToInt32(qnt_turmas.Text),
                QntAlunos = Convert.ToInt32(qnt_alunos.Text),
                ValorRepasse = Convert.ToDouble(repasse.Text),
                Producao = pck_tipo_producao.SelectedItem.ToString(),
                DataCol = data_col.Date,
                DataBaile = data_baile.Date,
                Obs = string.IsNullOrEmpty(observacoes.Text) ? "..." : observacoes.Text,
                NomeOperador = operador.Text,
            };

            //DisplayAlert("Valor Selecionado", $"Você escolheu: {Brf.ToString()}", "OK");

            string caminho = Path.Combine(FileSystem.AppDataDirectory, $"Briefing - {nome_inst.Text}.pdf");


            //string caminhoDownloads = GetDownloadsPath();

            //string downloadsPath = MainActivity.Instance.GetDownloadsPath();



            Console.WriteLine($"Caminho da pasta Downloads: {caminho}");

            //string caminho = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath, $"Briefing - {nome_inst.Text}.pdf");


            PDFs pdfs = new PDFs();
            await pdfs.GerarPdf(caminho, Brf);


            //await DisplayAlert("Sucesso", $"PDF gerado em: {caminho}", "OK");

            bool resposta = await DisplayAlert("Sucesso", $"PDF gerado em: {caminho}", "Compartilhar", "OK");

            if (resposta)
            {
                await Share.Default.RequestAsync(new ShareFileRequest
                {
                    Title = "Compartilhar PDF",
                    File = new ShareFile(caminho)
                });
                await Navigation.PopAsync();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops ", ex.Message, "Ok");
        }
    }
}