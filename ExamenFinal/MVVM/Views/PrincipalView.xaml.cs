using ExamenFinal.MVVM.ViewModels;

namespace ExamenFinal.MVVM.Views;

public partial class PrincipalView : ContentPage
{
    public PrincipalViewModel vm { get; set; }
    public PrincipalView()
	{
		InitializeComponent();
        vm = new PrincipalViewModel();
        BindingContext = vm;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new BuscadorView()
        {
            BindingContext = vm
        });
    }
}