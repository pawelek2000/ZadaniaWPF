using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM.Core;
using WpfMVVM.MVVM.Model;
using WpfMVVM.MVVM.View;

namespace WpfMVVM.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand OtworzCommand { get; set; }
        public RelayCommand NowaKwestiaCommand { get; set; }
        public RelayCommand NowyElementKwestiiCommand { get; set; }
        public RelayCommand BartoszCommand { get; set; }
        public MainViewModel()
        {

            ListaKwestii = new ObservableCollection<Kwestia>();
            
            OtworzCommand = new RelayCommand(o => 
            {
                var kwestia = (o as Kwestia);
                var index = ListaKwestii.IndexOf(kwestia);
                if (kwestia.IsOpened == Visibility.Collapsed)
                    ListaKwestii[index].IsOpened = Visibility.Visible;
                else
                    ListaKwestii[index].IsOpened = Visibility.Collapsed;
            });

            NowaKwestiaCommand = new RelayCommand(o =>
            {
                var window = new KwestiaWindow();
                var windowContext = new KwestiaViewModel();
                windowContext.ListaKwestii = ListaKwestii;
                window.DataContext = windowContext;
                window.ShowDialog();
            });

            NowyElementKwestiiCommand = new RelayCommand(o =>
            {
                var kwestia = (o as Kwestia);
                var window = new NowyElementView();
                var windowContext = new NowyElementViewModel();
                windowContext.ListaKwestii = ListaKwestii;
                windowContext.WybranaKwestia = kwestia;
                window.DataContext = windowContext;
                window.ShowDialog();
            });
            BartoszCommand = new RelayCommand(o => 
            {
                string Tekst = "";
                foreach (var k in ListaKwestii) 
                {
                    Tekst += k.KonwertujDoBartoszSacharczuk();
                }

                BartoszSacharczukAdapter.UzyjBartka(Tekst);
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

        
    }
}
