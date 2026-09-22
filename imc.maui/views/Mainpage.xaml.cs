using imc.maui.Models;

namespace imc.maui.views;

public partial class Mainpage : ContentPage
{
	public Mainpage()
	{
		InitializeComponent();
        Imclabel.Text = string.Empty;
        SituacionNutricionalLabel.Text = string.Empty;
	}

    private void OnCalcularButtonClicked(object sender, EventArgs e)
    {
        decimal peso;
        decimal estatura;
        peso = decimal.Parse(PesoEntry.Text);
        estatura = decimal.Parse(EstaturaEntry.Text);
        decimal imc = CalculadoraImc.IndicedeMasaCorporal(peso,estatura);
        Imclabel.Text = imc.ToString("f4");
        SituacionNutricionalLabel.Text = CalculadoraImc.SituacionNutricional(imc);
    }

    private void OnLimpiarButtonClicked(object sender, EventArgs e)
    {
        PesoEntry.Text = string.Empty;
        EstaturaEntry.Text = string.Empty;
        Imclabel.Text = string.Empty;
        SituacionNutricionalLabel.Text = string.Empty;
    }
}