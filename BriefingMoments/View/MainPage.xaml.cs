using BriefingMoments.View;

namespace BriefingMoments
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            //operador.Text = operador: Operador.nome;
        }

        private void Insert_brf_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewBriefing());
            
        }

        private void Select_brf_Clicked(object sender, EventArgs e)
        {
            
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
