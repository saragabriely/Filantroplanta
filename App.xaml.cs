using Filantroplanta.Views;
using Filantroplanta.Views.Produtor;
using Microsoft.Maui.Controls;

namespace Filantroplanta;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        var nav = new NavigationPage(new Login());

        //NavigationPage.SetTitleIconImageSource(this, "icone.png");

        nav.BarBackgroundColor = Colors.DarkGreen;
        nav.BarTextColor = Colors.White;
        //nav.IconImageSource = "icone.png";

        MainPage = nav;
    }
}
