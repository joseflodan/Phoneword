namespace Phoneword;

public partial class MainPage : ContentPage
{
    string numeroTraducido;

    public MainPage()
	{
		InitializeComponent();
	}

    private void AlTraducir(object sender, EventArgs e)
    {
        string numeroIntroducido = TextoNumero.Text;
        numeroTraducido = PhonewordTranslator.ToNumber(numeroIntroducido);

        if (!string.IsNullOrEmpty(numeroTraducido))
        {
            BotonLlamar.IsEnabled = true;
            BotonLlamar.Text = "Llamar a " + numeroTraducido;
        }
        else
        {
            BotonLlamar.IsEnabled = false;
            BotonLlamar.Text = "Llamar";
        }
    }

    private async void AlLlamar(object sender, EventArgs e)
    {
        if (await this.DisplayAlert(
                "Contactar al numero",
                "¿Te gustaria llamar a "+ numeroTraducido +"?",
                "Si",
                "No"
            ))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(numeroTraducido);
            } 
            catch (ArgumentNullException)
            {
                await DisplayAlert("Imposible realizar acción", "El numero es incorrecto.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Imposible realizar acción", "El telefono esta fallando.", "OK");
            }
        }
    }
}


