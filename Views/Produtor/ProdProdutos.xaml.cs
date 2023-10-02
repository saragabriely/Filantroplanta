using Filantroplanta.Models;
using Filantroplanta.Mock;
using Filantroplanta.Controle.Produtor;

namespace Filantroplanta.Views.Produtor;

public partial class ProdProdutos : ContentPage
{
	public ProdProdutos()
	{
		InitializeComponent();

        BuscarProdutos();
    }

    private void BuscarProdutos()
    {
        var ctrlProduto = new ControleProduto();

        var lista = ctrlProduto.MockListaProdutos();

        if(lista != null )
        {
            listaProdutos.ItemsSource = lista;
            stListaProdutos.IsVisible = true;
            lblListaVazia.IsVisible   = false;
        }
    }

    private void ButtonAdicionarProduto_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProdCadastroProduto());
    }

    private void listaProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Produto produto = e.SelectedItem as Produto;

        if (produto != null)
            NavegarTelaCadastro(produto);
    }

    private void NavegarTelaCadastro(Produto produto)
    {
        Navigation.PushAsync(new ProdCadastroProduto(produto));
    }
}