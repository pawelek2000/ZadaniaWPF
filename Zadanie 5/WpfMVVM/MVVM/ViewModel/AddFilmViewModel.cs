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
    internal class AddFilmViewModel : ObservableObject
    {
        public RelayCommand ZatwierdzCommand { get; set; }
        public RelayCommand AnulujCommand { get; set; }
        public bool IsNewFilm { get; set; }
        public AddFilmViewModel()
        {
            ZatwierdzCommand = new RelayCommand(o => 
            {
                var window = o as Window;
                if (IsNewFilm)
                {
                    var index = -1;
                    if(BazaFilmow.Count>0)
                        index = BazaFilmow.Max(f => f.Id);
                    SelectedFilm.Id = ++index;
                    BazaFilmow.Add(SelectedFilm);
                }
                else 
                {
                    var index = BazaFilmow.IndexOf(SelectedFilm);
                    BazaFilmow[index] = SelectedFilm;
                }

                if (window != null)
                {
                    window.Close();
                }
            });

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

        public ObservableCollection<Film> BazaFilmow
        {
            get { return _BazaFilmow; }
            set
            {
                _BazaFilmow = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Film> _BazaFilmow;
    }
}
