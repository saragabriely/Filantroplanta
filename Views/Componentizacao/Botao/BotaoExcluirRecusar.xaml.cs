namespace Filantroplanta.Views.Componentizacao.Botao;

public partial class BotaoExcluirRecusar : ContentView
{
	public BotaoExcluirRecusar()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TituloProperty = BindableProperty.Create(nameof(Titulo), typeof(string), typeof(BotaoExcluirRecusar));
    public string Titulo
    {
        get
        {
            return GetValue(TituloProperty) as string;
        }
        set
        {
            SetValue(TituloProperty, value);
        }
    }
}