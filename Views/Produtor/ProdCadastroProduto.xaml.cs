using Filantroplanta.Models;

namespace Filantroplanta.Views.Produtor;

public partial class ProdCadastroProduto : ContentPage
{
	public ProdCadastroProduto()
	{
		InitializeComponent();
	}

    private void ButtonCadastrarProduto_Clicked(object sender, EventArgs e)
    {
        RealizarCadastroProduto();
    }

    private void ButtonCancelar_Clicked(object sender, EventArgs e)
    {
        NavegarListaProdutos();
    }

    public void NavegarListaProdutos()
    {
        Navigation.PushAsync(new ProdProdutos());
    }

    private async void RealizarCadastroProduto()
    {
        var nomeProduto = entNomeProduto.Text;
        var quantidade  = entQtde.Text;
        var valorPorKG  = entValorPorKG.Text;

        if (string.IsNullOrEmpty(nomeProduto))
            LancarExcecaoCampoVazio("NOME DO PRODUTO");

        else if (string.IsNullOrEmpty(quantidade))
            LancarExcecaoCampoVazio("QUANTIDADE");

        else if (string.IsNullOrEmpty(valorPorKG))
            LancarExcecaoCampoVazio("VALOR");

        else
        {
            var produto = new Produto();

            produto.Descricao = nomeProduto;
            produto.Quantidade = Convert.ToInt64(quantidade);
            produto.ValorPorKG = Convert.ToDecimal(valorPorKG);

            await DisplayAlert("Cadastro realizado", "Cadastro realizado com sucesso!", "OK");

            NavegarListaProdutos();
        }
    }

    public async void LancarExcecaoCampoVazio(string campo)
    {
        await DisplayAlert("Campo Vazio", $"Popule o campo '{campo}'", "OK");
    }

}