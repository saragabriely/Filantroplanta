using Filantroplanta.Controle;
using Filantroplanta.Controle.Produtor;
using Filantroplanta.Mock;
using Filantroplanta.Models;
using Filantroplanta.Views.Componentizacao.Botao;
using Filantroplanta.Views.Componentizacao.Label_Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace Filantroplanta.Views.Produtor;

public partial class ProdCadastroProduto : ContentPage
{
    public Produto produto { get; set; }
    public MockGeral mock = new MockGeral();
    public ControleProduto controleProduto = new ControleProduto();
    public BotoesCancelarSalvar btnCancelarSalvar = new BotoesCancelarSalvar();
    public BotaoExcluirRecusar  btnExcluirRecusar = new BotaoExcluirRecusar();
    public LabelInput  labelInput = new LabelInput();
    public ControleComponentizacao controleComponente = new ControleComponentizacao();

    public ProdCadastroProduto()
	{
		InitializeComponent();

        this.BotoesCancelarSalvar("Cancelar", "Finalizar");
    }

    private void BotoesCancelarSalvar(string btnCancelar, string btnSalvar)
    {
        hsBotoesSalvarCancelar.Children.Add(btnCancelarSalvar);

        var botaoSalvar = btnCancelarSalvar.FindByName<Button>(controleComponente.NomeBotaoSalvar);
        if (botaoSalvar != null)
        {
            botaoSalvar.Clicked += this.ButtonSalvarProduto_Clicked;
            btnCancelarSalvar.TituloSalvar = btnSalvar;
        }

        var botaoCancelar = btnCancelarSalvar.FindByName<Button>(controleComponente.NomeBotaoCancelar);
        if (botaoCancelar != null)
        {
            botaoCancelar.Clicked += this.ButtonCancelar_Clicked;
            btnCancelarSalvar.TituloCancelar = btnCancelar;
        }
    }

    private void BotaoExcluir(string btnExcluir)
    {
        slBotaoExcluir.Children.Add(btnExcluirRecusar);

        var botaoExcluir = btnExcluirRecusar.FindByName<Button>(controleComponente.NomeBotaoExcluirRecusar);
        if (botaoExcluir != null)
        {
            botaoExcluir.Clicked  += this.ButtonExcluirProduto_Clicked;
            botaoExcluir.IsVisible = true;
            btnExcluirRecusar.Titulo = btnExcluir;
        }
    }

    public ProdCadastroProduto(Produto produto)
    {
        InitializeComponent();

        this.BotoesCancelarSalvar("Cancelar", "Salvar");
        this.BotaoExcluir("Excluir");

        if (produto != null)
        {
            this.produto = produto;

            entNomeProduto.TextEntry = this.produto.Descricao;
            entQtde.TextEntry        = this.produto.Quantidade.ToString();
            entValorPorKG.TextEntry  = this.produto.ValorPorKG.ToString();

            //entQtde.Text        = this.produto.Quantidade.ToString();
            //ValorPorKG.Text  = this.produto.ValorPorKG.ToString();

            slBotaoExcluir.IsVisible   = true;
        }
    }

    private void ButtonSalvarProduto_Clicked(object sender, EventArgs e)
    {
        RealizarCadastroProduto();
    }

    private async void ButtonExcluirProduto_Clicked(object sender, EventArgs e)
    {
        if(this.produto != null)
        {
            bool resposta = await DisplayAlert("Exclusão", "Confirma a exclusão do produto?", "Sim", "Não");

            if(resposta)
                ExcluirProduto(this.produto);
        }
        else
            await DisplayAlert("Produto vazio", "Ocorreu algum problema com o produto", "OK");
    }

    private void ExcluirProduto(Produto produto)
    {
        if(produto != null && produto.Produto_ID > 0)
        {
            var listaProdutos = controleProduto.ExcluirProdutoCache(produto);

            Voltar(listaProdutos);
        }
    }

    private void ButtonCancelar_Clicked(object sender, EventArgs e)
    {
        Voltar();
    }

    public void Voltar(List<Produto> listaProdutos)
    {
        Navigation.PushAsync(new ProdProdutos(listaProdutos));
    }

    public void Voltar()
    {
        Navigation.PopAsync();
    }

    public void NavegarListaProdutos()
    {
        Voltar();
    }

    private async void RealizarCadastroProduto()
    {
        long pessoaID   = 0;
        var nomeProduto = entNomeProduto.TextEntry;
        var quantidade  = entQtde.TextEntry;
        var valorPorKG  = entValorPorKG.TextEntry;

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

                controleProduto.SalvarAdicionarProduto(this.produto);

                await DisplayAlert("Cadastro atualizado", "Cadastro atualizado com sucesso!", "OK");
            }
            else
            {
                var novo = new Produto();

                novo.Descricao = nomeProduto;
                novo.Quantidade = Convert.ToInt64(quantidade);
                novo.ValorPorKG = Convert.ToDecimal(valorPorKG);
                novo.mProdutor  = new Pessoa { Pessoa_ID = pessoaID };

                controleProduto.SalvarAdicionarProduto(novo);

                await DisplayAlert("Cadastro realizado", "Cadastro realizado com sucesso!", "OK");
            }

            Voltar(controleProduto.BuscarListaProdutoCache());
        }
    }

    public async void LancarExcecaoCampoVazio(string campo)
    {
        await DisplayAlert("Campo Vazio", $"Popule o campo '{campo}'", "OK");
    }
}