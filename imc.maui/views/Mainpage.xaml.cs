using imc.maui.ViewModels;

namespace imc.maui.views;

public partial class Mainpage : ContentPage
{
	public Mainpage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
	}

}