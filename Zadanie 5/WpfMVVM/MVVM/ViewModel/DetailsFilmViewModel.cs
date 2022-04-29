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
    internal class DetailsFilmViewModel : ObservableObject
    {
        public RelayCommand AnulujCommand { get; set; }
        public ObservableCollection<Film> BazaFilmow { get; set; }
        public DetailsFilmViewModel()
        {
            AnulujCommand = new RelayCommand(o =>
            {
                var window = o as Window;
                if (window != null)
                {
                    window.Close();
                }
            });

        }

        public Film SelectedFilm
        {
            get { return _selectedFilm; }
            set
            {
                _selectedFilm = value;
                OnPropertyChanged();
            }
        }
        private Film _selectedFilm;

       
    }
}
