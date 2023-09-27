using System.Windows.Input;
using Filantroplanta.Views.Usuario;

namespace Filantroplanta.Views;

public partial class Login : ContentPage
{
    public Login()
	{
		InitializeComponent();
	}

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CadastroPessoa());
    }

    //private async void CliqueAquiEsqueceuEmail(object sender, EventArgs e)
    //{
    //    await Navigation.PushModalAsync(new Views.Pessoa.CadastroPessoa());
    //}
}