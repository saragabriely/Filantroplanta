using Filantroplanta.Controle.Produtor;
using Filantroplanta.Models;

namespace Filantroplanta.Views.Produtor;

public partial class ProdCadastroProduto : ContentPage
{
    public Produto produto { get; set; }

    public ProdCadastroProduto()
	{
		InitializeComponent();
	}

    public ProdCadastroProduto(Produto produto)
    {
        InitializeComponent();

        this.produto = produto;

        entNomeProduto.Text = produto.Descricao;
        entQtde.Text        = produto.Quantidade.ToString();
        entValorPorKG.Text  = produto.ValorPorKG.ToString();

        btnExcluir_.IsVisible   = true;
        btnSalvar_.IsVisible    = true;
        btnCadastrar_.IsVisible = false;
    }

    private void ButtonSalvarProduto_Clicked(object sender, EventArgs e)
    {
        RealizarCadastroProduto();
    }

    private void ButtonCadastrarProduto_Clicked(object sender, EventArgs e)
    {
        RealizarCadastroProduto();
    }

    private void ButtonExcluirProduto_Clicked(object sender, EventArgs e)
    {
        ExcluirProduto();
    }

    private void ExcluirProduto()
    {
        if(produto != null && produto.Produto_ID > 0)
        {

            NavegarListaProdutos();
        }
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
        long pessoaID = 0;
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
            var controleProduto = new ControleProduto();

            if(this.produto != null && this.produto.Produto_ID > 0)
            {
                this.produto.Descricao  = nomeProduto;
                this.produto.Quantidade = Convert.ToInt64(quantidade);
                this.produto.ValorPorKG = Convert.ToDecimal(valorPorKG);

                controleProduto.SalvarProduto(this.produto);

                await DisplayAlert("Cadastro atualizado", "Cadastro atualizado com sucesso!", "OK");
            }
            else
            {
                var novo = new Produto();

                novo.Descricao = nomeProduto;
                novo.Quantidade = Convert.ToInt64(quantidade);
                novo.ValorPorKG = Convert.ToDecimal(valorPorKG);
                novo.mProdutor  = new Pessoa { Pessoa_ID = pessoaID };

                controleProduto.CadastrarProduto(novo);

                await DisplayAlert("Cadastro realizado", "Cadastro realizado com sucesso!", "OK");
            }

            NavegarListaProdutos();
        }
    }

    public async void LancarExcecaoCampoVazio(string campo)
    {
        await DisplayAlert("Campo Vazio", $"Popule o campo '{campo}'", "OK");
    }
}