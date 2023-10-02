using Filantroplanta.Models;

namespace Filantroplanta.Views.Usuario;

public partial class CadastroPessoa : ContentPage
{
	public CadastroPessoa()
	{
		InitializeComponent();

        //NavigationPage.SetTitleIconImageSource(this, "icone.png");
    }

    private void ButtonCancelar_Clicked(object sender, EventArgs e)
    {
        VoltarTelaLogin();
    }

    private async void ButtonFinalizar_Clicked(object sender, EventArgs e)
    {
        await RealizarCadastro();
    }

    public async Task RealizarCadastro()
    {
        var nome           = entNome.Text;
        var documento      = entDocumento.Text;
        var cep            = entCep.Text;
        var endereco       = entEndereco.Text;
        var numero         = entNumero.Text;
        var complemento    = entComplemento.Text;
        var bairro         = entBairro.Text;
        var cidade         = entCidade.Text;
        var estado         = entEstado.Text;
        var telefone       = entTelefone.Text;
        var email          = entEmail.Text;
        var senha          = entSenha.Text;
        var confirmarSenha = entConfirmaSenha.Text;

        if (string.IsNullOrEmpty(nome))
            LancarExcecaoCampoVazio("NOME");

        else if (string.IsNullOrEmpty(documento))
            LancarExcecaoCampoVazio("DOCUMENTO");

        else if (string.IsNullOrEmpty(cep))
            LancarExcecaoCampoVazio("CEP");

        else if (string.IsNullOrEmpty(endereco))
            LancarExcecaoCampoVazio("ENDEREÇO");

        else if (string.IsNullOrEmpty(numero))
            LancarExcecaoCampoVazio("NUMERO");

        else if (string.IsNullOrEmpty(bairro))
            LancarExcecaoCampoVazio("BAIRRO");

        else if (string.IsNullOrEmpty(cidade))
            LancarExcecaoCampoVazio("CIDADE");

        else if (string.IsNullOrEmpty(estado))
            LancarExcecaoCampoVazio("ESTADO");

        else if (string.IsNullOrEmpty(telefone))
            LancarExcecaoCampoVazio("TELEFONE");

        else if (string.IsNullOrEmpty(email))
            LancarExcecaoCampoVazio("EMAIL");

        else if (string.IsNullOrEmpty(senha))
            LancarExcecaoCampoVazio("SENHA");

        else if (string.IsNullOrEmpty(confirmarSenha))
            LancarExcecaoCampoVazio("CONFIRMAÇÃO DE SENHA");

        else if (!confirmarSenha.Equals(senha))
            await DisplayAlert("Senha", "As senhas não coincidem", "OK");
        else
        {
            var tp = rbRestaurante.IsChecked ? TipoPessoa.Restaurante : TipoPessoa.Produtor;

            var pessoa = new Pessoa();

            pessoa.Nome      = nome;
            pessoa.Documento = documento;
            pessoa.CEP       = cep;
            pessoa.Endereco  = endereco;
            pessoa.Numero    = Convert.ToInt32(numero);
            pessoa.Complemento = complemento;
            pessoa.Bairro    = bairro;
            pessoa.Cidade    = cidade;
            pessoa.Estado    = estado;
            pessoa.Telefone  = telefone;
            pessoa.Email     = email;
            pessoa.Senha     = senha;
            pessoa.mTipoPessoa = new TipoPessoa { TipoPessoa_ID = tp };

            await DisplayAlert("Cadastro realizado", "Cadastro realizado com sucesso!", "OK");

            VoltarTelaLogin();
        }        
    }

    public async void LancarExcecaoCampoVazio(string campo)
    {
        await DisplayAlert("Campo Vazio", $"Popule o campo '{campo}'", "OK");
    }

    private void VoltarTelaLogin()
    {
        Navigation.PushAsync(new Login());
    }

}