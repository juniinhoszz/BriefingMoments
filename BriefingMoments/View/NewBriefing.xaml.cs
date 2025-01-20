namespace BriefingMoments.View;

public partial class NewBriefing : ContentPage
{
	public NewBriefing()
	{
		InitializeComponent();
	}

    private void back_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}