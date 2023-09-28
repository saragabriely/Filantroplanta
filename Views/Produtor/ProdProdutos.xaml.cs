namespace Filantroplanta.Views.Produtor;

public partial class ProdProdutos : ContentPage
{
	public ProdProdutos()
	{
		InitializeComponent();
	}

    private void ButtonAdicionarProduto_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProdCadastroProduto());

        //entNomeProduto.Text;
    }
}