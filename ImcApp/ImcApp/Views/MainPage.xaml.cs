using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ImcApp.Models;
using ImcApp.ViewModels;

namespace ImcApp.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
            //LimpiarIU();
        }

        private void calcularButton_Clicked(object sender, EventArgs e)
        {
            //decimal peso;
            //decimal estatura;
            //bool pesoEsConvertible = decimal.TryParse(pesoEntry.Text, out peso);
            //bool estaturaEsConvertible = decimal.TryParse(estaturaEntry.Text, out estatura);
            //if (pesoEsConvertible && estaturaEsConvertible)
            //{
            //    CalculadoraImc cimc = new CalculadoraImc(peso, estatura);
            //    imcLabel.Text = string.Format("{0:F4}", cimc.Imc);
            //    situacionNutricionalLabel.Text = GetEstadoNutricional(cimc.SituacionNutricional);
            //}

            viewModel.Imc = CalculadoraImc.IndiceDeMasaCorporal(viewModel.Peso, viewModel.Estatura);
            viewModel.SituacionNutricional = GetEstadoNutricional(CalculadoraImc.SituacionNutricional(viewModel.Imc));
        }
        private void limpiarButton_Clicked(object sender, EventArgs e)
        {
            LimpiarIU();
        }

        private void LimpiarIU()
        {
            //pesoEntry.Text = string.Empty;
            //estaturaEntry.Text = string.Empty;
            //imcLabel.Text = string.Empty;
            //situacionNutricionalLabel.Text = string.Empty;
        }


        private string GetEstadoNutricional(CalculadoraImc.EstadoNutricional estatus)
        {

            switch (estatus)
            {
                case CalculadoraImc.EstadoNutricional.PesoBajo:
                    return Resources["TextoPesoBajo"] as string;
                case CalculadoraImc.EstadoNutricional.PesoNormal:
                    return Resources["TextoPesoNormal"] as string;
                case CalculadoraImc.EstadoNutricional.SobrePeso:
                    return Resources["TextoSobrePeso"] as string;
                case CalculadoraImc.EstadoNutricional.Obesidad:
                    return Resources["TextoObesidad"] as string;
                case CalculadoraImc.EstadoNutricional.ObesidadExtrema:
                    return Resources["TextoObesidadExtrema"] as string;
                default:
                    return string.Empty;
            }

        }
    }
}
