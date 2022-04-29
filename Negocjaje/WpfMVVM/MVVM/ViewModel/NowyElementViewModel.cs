using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM.Core;
using WpfMVVM.MVVM.Model;

namespace WpfMVVM.MVVM.ViewModel
{
    internal class NowyElementViewModel : ObservableObject
    {
        public RelayCommand NowaKwestiaCommand { get; set; }
        public NowyElementViewModel()
        {
            NowaKwestiaCommand = new RelayCommand(o =>
            {
                var window = o as Window;
                ElementKwestii temp = new ElementKwestii()
                {
                    Opcja = mojaOpcja,
                    Ocena = mojaOcena

                };

                var index = ListaKwestii.IndexOf(WybranaKwestia);
                ListaKwestii[index].ElementyKwestii.Add(temp);

                if (window != null)
                {
                    window.Close();
                }
            });
        }

        public ObservableCollection<Kwestia> ListaKwestii
        {
            get { return _listaKwestii; }
            set
            {
                _listaKwestii = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Kwestia> _listaKwestii;

        public Kwestia WybranaKwestia
        {
            get { return _wybranaKwestia; }
            set
            {
                _wybranaKwestia = value;
                OnPropertyChanged();
            }
        }
        private Kwestia _wybranaKwestia;

        public string mojaOpcja
        {
            get { return _opcja; }
            set
            {
                _opcja = value;
                OnPropertyChanged();
            }
        }
        private string _opcja;

        public int mojaOcena
        {
            get { return _mojaOcena; }
            set
            {
                _mojaOcena = value;
                OnPropertyChanged();
            }
        }
        private int _mojaOcena;
    }
}
