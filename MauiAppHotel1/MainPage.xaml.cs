using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel1
{
    public partial class MainPage : ContentPage
    {
        int adultos = 0;
        int criancas = 0;

        public MainPage()
        {
            InitializeComponent();

            DatePickerCheckIn.Date = DateTime.Today;
            DatePickerCheckOut.Date = DateTime.Today.AddDays(1);
        }

        private void OnAdultosMinusClicked(object sender, EventArgs e)
        {
            if (adultos > 0)
            {
                adultos--;
                LabelAdultos.Text = adultos.ToString();
            }
        }

        private void OnAdultosPlusClicked(object sender, EventArgs e)
        {
            adultos++;
            LabelAdultos.Text = adultos.ToString();
        }

        private void OnCriancasMinusClicked(object sender, EventArgs e)
        {
            if (criancas > 0)
            {
                criancas--;
                LabelCriancas.Text = criancas.ToString();
            }
        }

        private void OnCriancasPlusClicked(object sender, EventArgs e)
        {
            criancas++;
            LabelCriancas.Text = criancas.ToString();
        }

        private void OnAvancarClicked(object sender, EventArgs e)
        {
            if (PickerSuite.SelectedIndex == -1)
            {
                DisplayAlert("Erro", "Por favor, selecione uma suíte.", "OK");
                return;
            }

            if (DatePickerCheckOut.Date <= DatePickerCheckIn.Date)
            {
                DisplayAlert("Erro", "A data de check-out deve ser maior que a de check-in.", "OK");
                return;
            }

            if (adultos + criancas == 0)
            {
                DisplayAlert("Erro", "Informe ao menos um hóspede.", "OK");
                return;
            }

            int dias = (DatePickerCheckOut.Date - DatePickerCheckIn.Date).Days;

            double precoPorDia = PickerSuite.SelectedIndex switch
            {
                0 => 100,
                1 => 200,
                2 => 300,
                _ => 0
            };

            double total = precoPorDia * dias;

            DisplayAlert("Total da Diária", $"Total para {dias} noites na {PickerSuite.Items[PickerSuite.SelectedIndex]}: R$ {total:F2}", "OK");
        }

        private void OnSobreClicked(object sender, EventArgs e)
        {
            DisplayAlert("Sobre", "App de Cálculo de Diária - Exemplo criado com MAUI.", "OK");
        }
    }
}
