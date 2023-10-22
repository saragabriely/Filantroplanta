namespace Filantroplanta.Views.Componentizacao.Label_Input;

public partial class LabelInput : ContentView
{
	public LabelInput()
	{
        InitializeComponent();
	}

    public static readonly BindableProperty TextLabelProperty = BindableProperty.Create(nameof(TextLabel), typeof(string), typeof(LabelInput));
    public string TextLabel
    {
        get
        {
            return GetValue(TextLabelProperty) as string;
        }
        set
        {
            SetValue(TextLabelProperty, value);
        }
    }

    public static readonly BindableProperty PlaceholderEntryProperty = BindableProperty.Create(nameof(PlaceholderEntry), typeof(string), typeof(LabelInput));
    public string PlaceholderEntry
    {
        get
        {
            return GetValue(PlaceholderEntryProperty) as string;
        }
        set
        {
            SetValue(PlaceholderEntryProperty, value);
        }
    }

    public static readonly BindableProperty TextEntryProperty = BindableProperty.Create(nameof(TextEntry), typeof(string), typeof(LabelInput));
    public string TextEntry
    {
        get
        {
            return GetValue(TextEntryProperty) as string;
        }
        set
        {
            SetValue(TextEntryProperty, value);
        }
    }

    public static readonly BindableProperty TipoCampoProperty = BindableProperty.Create(nameof(TipoCampo), typeof(string), typeof(LabelInput));
    public string TipoCampo
    {
        get
        {
            return GetValue(TipoCampoProperty) as string;
        }
        set
        {
            SetValue(TipoCampoProperty, value);
        }
    }
}