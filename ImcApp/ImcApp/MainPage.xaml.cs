using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ImcApp.Model;

namespace ImcApp
{
    public partial class MainPage : ContentPage
    {
        private CalculadoraImc imc;
        public MainPage()
        {
            InitializeComponent();
            LimpiarIU();
        }

        private void calcularButton_Clicked(object sender, EventArgs e)
        {
            decimal peso;
            decimal estatura;
            bool pesoEsConvertible = decimal.TryParse(pesoEntry.Text, out peso);
            bool estaturaEsConvertible = decimal.TryParse(estaturaEntry.Text, out estatura);
            if (pesoEsConvertible && estaturaEsConvertible)
            {
                CalculadoraImc cimc = new CalculadoraImc(peso, estatura);
                imcLabel.Text = string.Format("{0:F4}", cimc.Imc);
                situacionNutricionalLabel.Text = Convert.ToString(cimc.SituacionNutricional);
            }
            else
            {
                DisplayAlert(
                "Alerta",
                "El peso y la estatura deben ser valores numéricos.",
                "Aceptar"
                );
            }


        }
        private void limpiarButton_Clicked(object sender, EventArgs e)
        {
            LimpiarIU();
        }

        private void LimpiarIU()
        {
            pesoEntry.Text = string.Empty;
            estaturaEntry.Text = string.Empty;
            imcLabel.Text = string.Empty;
            situacionNutricionalLabel.Text = string.Empty;
        }

    }
}
