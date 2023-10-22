namespace Filantroplanta.Views.Componentizacao.Botao;

public partial class BotoesCancelarSalvar : ContentView
{
	public BotoesCancelarSalvar()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TituloSalvarProperty = BindableProperty.Create(nameof(TituloSalvar), typeof(string), typeof(BotoesCancelarSalvar));
    public string TituloSalvar
    {
        get
        {
            return GetValue(TituloSalvarProperty) as string;
        }
        set
        {
            SetValue(TituloSalvarProperty, value);
        }
    }

    public static readonly BindableProperty TituloCancelarProperty = BindableProperty.Create(nameof(TituloCancelar), typeof(string), typeof(BotoesCancelarSalvar));
    public string TituloCancelar
    {
        get
        {
            return GetValue(TituloCancelarProperty) as string;
        }
        set
        {
            SetValue(TituloCancelarProperty, value);
        }
    }
}