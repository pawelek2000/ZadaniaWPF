using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM.Core;

namespace WpfMVVM.MVVM.Model
{
    internal class Kwestia : ObservableObject
    {
       

        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                _nazwa = value;
                OnPropertyChanged();
            }
        }
        private string _nazwa;
        public ObservableCollection<ElementKwestii> ElementyKwestii
        {
            get { return _elementyKwestii; }
            set
            {
                _elementyKwestii = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ElementKwestii> _elementyKwestii;

        public Visibility IsOpened
        {
            get { return _isOpened; }
            set
            {
                _isOpened = value;
                OnPropertyChanged();
            }
        }
        private Visibility _isOpened;

        public string KonwertujDoBartoszSacharczuk() 
        {
            string Bartek = "";
            foreach (var element in ElementyKwestii) 
            {
                Bartek += Nazwa + ":" + element.Opcja + "," + element.Ocena + "\n";
            }
            return Bartek;
        }
    }
}
