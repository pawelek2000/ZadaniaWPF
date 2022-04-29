using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM.Core;
using WpfMVVM.MVVM.Model;

namespace WpfMVVM.MVVM.ViewModel
{
    internal class MainViewModel :ObservableObject 
    {
        public RelayCommand odswiezCommand { get; set; }
        public RelayCommand zamknijCommand { get; set; }
        public RelayCommand zatwierdzCommand { get; set; }
        public MainViewModel()
        {
            zamowienie = new Zamowienie();
            odswiezCommand = new RelayCommand(o=> 
            {
                zamowienie.PodsumowanieZamowienia();
            });

            zamknijCommand = new RelayCommand(o => 
            {
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
            });
            zatwierdzCommand = new RelayCommand(o => 
            {
                MessageBox.Show("Zamównie przyjete");
                zamowienie = new Zamowienie();
            });
        }

        public Zamowienie zamowienie
        {
            get { return _zamowienie; }
            set
            {
                _zamowienie = value;
                OnPropertyChanged();
            }
        }
        private Zamowienie _zamowienie;
        
       

    }
}
