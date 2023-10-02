using Filantroplanta.Models;
using Filantroplanta.Mock;

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
        var lista = MockListaProdutos();

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
        //await DisplayAlert("Produto", produto.Descricao, "OK");

        Navigation.PushAsync(new ProdCadastroProduto(produto));
    }

    public List<Produto> MockListaProdutos()
    {
        var mock = new MockGeral();
        var listaProdutos = new List<Produto>();
                                                                                                                         
        listaProdutos.Add(mock.MockProduto01());
        listaProdutos.Add(mock.MockProduto02());

        return listaProdutos; 
    }
}