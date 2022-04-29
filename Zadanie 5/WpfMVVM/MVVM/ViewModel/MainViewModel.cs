using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public RelayCommand DodajCommand { get; set; }
        public RelayCommand EdytujCommand { get; set; }
        public RelayCommand UsunCommand { get; set; }
        public RelayCommand PodgladCommand { get; set; }
        public MainViewModel()
        {
            //WidocznoscPaskaDolnego = Visibility.Hidden;
            BazaFilmow = new ObservableCollection<Film>();
           
            UsunCommand = new RelayCommand(o=>
            {
                if (MessageBox.Show("Czy chcesz usunąc film?", "Usuwanie filmu", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BazaFilmow.Remove(SelectedFilm);
                }
               
                
            });
            DodajCommand = new RelayCommand(o =>
            {
                var window = new AddFilmWindow();
                var windowContext = new AddFilmViewModel();
                windowContext.BazaFilmow = BazaFilmow;
                windowContext.IsNewFilm = true;
                windowContext.SelectedFilm = new Film { DataPremiery = DateTime.Now};
                window.DataContext = windowContext;
                window.ShowDialog();
            });

            EdytujCommand = new RelayCommand(o =>
            {
                var window = new AddFilmWindow();
                var windowContext = new AddFilmViewModel();
                windowContext.BazaFilmow = BazaFilmow;
                windowContext.IsNewFilm = false;
                windowContext.SelectedFilm = SelectedFilm;
                window.DataContext = windowContext;
                window.ShowDialog();
            });
            PodgladCommand = new RelayCommand(o =>
            {
                var window = new DetailsFilmWindow();
                var windowContext = new DetailsFilmViewModel();
                windowContext.SelectedFilm = SelectedFilm;
                windowContext.BazaFilmow = BazaFilmow;
                window.DataContext = windowContext;
                window.ShowDialog();
            });

        }
        public ObservableCollection<Film> BazaFilmow
        {
            get { return _bazaFilmow; }
            set
            {
                _bazaFilmow = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Film> _bazaFilmow;

        public Film SelectedFilm
        {
            get { return _selectedFilm; }
            set
            {
                _selectedFilm = value;
                if (SelectedFilm == null)
                    WidocznoscPaskaDolnego = false;
                else
                    WidocznoscPaskaDolnego = true;
                OnPropertyChanged();
            }
        }
        private Film _selectedFilm;

        public bool WidocznoscPaskaDolnego
        {
            get { return _WidocznoscPaskaDolnego; }
            set
            {
                _WidocznoscPaskaDolnego = value;
                OnPropertyChanged();
            }
        }
        private bool _WidocznoscPaskaDolnego;
    }
}
