using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie1_wpf.Core;
using zadanie1_wpf.MVVM.Model;

namespace zadanie1_wpf.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private Maszyna MaszynaLosujaca { get; set; }
        public RelayCommand DodajCommand { get; set; }
        public RelayCommand WyjmijComand { get; set; }

        public MainViewModel()
        {
            MaszynaLosujaca = new Maszyna();
            Zawartosc = MaszynaLosujaca.Zawartosc();

            DodajCommand = new RelayCommand(o =>
            {
                MaszynaLosujaca.Dodaj(TextBoxValue);
                Zawartosc = "Dodano: " + TextBoxValue + "\n" + "Kupony w maszynie: " + MaszynaLosujaca.Zawartosc();
            });
            WyjmijComand = new RelayCommand(o => 
            {
                if (MaszynaLosujaca.Pusta())
                {
                    Zawartosc = "Maszyna Losująca jest pusta.";
                }
                else 
                {
                    Zawartosc = "Wylosowany kupon: " + MaszynaLosujaca.Wyjmij();
                }
            });

        }
        public string Zawartosc
        {
            get { return _zawartosc; }
            set
            {
                _zawartosc = value;
                OnPropertyChanged();
            }
        }
        private string _zawartosc;

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set
            {
                _textBoxValue = value;
                OnPropertyChanged();
            }
        }
        private string _textBoxValue;
    }
}
