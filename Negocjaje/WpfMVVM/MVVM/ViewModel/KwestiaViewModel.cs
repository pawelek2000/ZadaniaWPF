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
    internal class KwestiaViewModel : ObservableObject
    {
        public RelayCommand NowaKwestiaCommand { get; set; }
        public KwestiaViewModel()
        {
            NowaKwestiaCommand = new RelayCommand(o => 
            {
                var window = o as Window;
                Kwestia temp = new Kwestia 
                {
                    Nazwa = NazwaKwestii,
                    ElementyKwestii = new ObservableCollection<ElementKwestii>(),
                    IsOpened = Visibility.Collapsed
                };
                ListaKwestii.Add(temp);
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

        public string NazwaKwestii
        {
            get { return _nazwaKwestii; }
            set
            {
                _nazwaKwestii = value;
                OnPropertyChanged();
            }
        }
        private string _nazwaKwestii;
    }
}
