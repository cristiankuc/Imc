using imc.maui.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace imc.maui.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private string _peso;
        private string _estatura;
        private string _imc;
        private string _estadoNutricional;
        private string? propertyName;

        public string Peso
        {
            get => _peso;
            set
            {
                if (Peso  != value)
                {
                    _peso = value;
                    OnPropetyChanged(nameof(Peso));
                }
            }
        }
        public string Estatura
        {
            get => _estatura;
            set
            {
                if (Estatura != value) {
                    _estatura = value;
                    OnPropetyChanged(nameof(_estatura));
                }
            }
        }

        public string Imc
        {
            get => _imc;
            set
            {
                if (_imc != value)
                {
                    _imc = value;
                    OnPropetyChanged(nameof(_imc));
                }
            }
        }

        public string EstadoNutricional
        {
            get => _estadoNutricional;
            set
            {
                if (_estadoNutricional != value)
                {
                    _estadoNutricional = value;
                    OnPropetyChanged(nameof(EstadoNutricional));
                }
            }
        }

        public ICommand CalcularCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }
        public MainViewModel()
            {
            LimpiarDatos();
            LimpiarCommand = new Command(LimpiarDatos);
            CalcularCommand = new Command(CalcularResultados);
             }
       
        private void CalcularResultados()
                {
            decimal peso;
            decimal estatura;
            bool PesoEsValido = decimal.TryParse(Peso, out peso);
            bool EstaturaEsValida = decimal.TryParse(Estatura, out estatura);
            if (PesoEsValido && EstaturaEsValida)
            {
                decimal imc = CalculadoraImc.IndicedeMasaCorporal(peso, estatura);
                Imc = imc.ToString("f4");
                EstadoNutricional = CalculadoraImc.SituacionNutricional(imc);
            }
                }
        private void LimpiarDatos()
        {
            Peso = string.Empty;
            Estatura = string.Empty;
            Imc = string.Empty;
            EstadoNutricional = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropetyChanged(string propetyName)
        {
            if (PropertyChanged != null )
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
           
        }
    }
}
