using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Core;

namespace WpfMVVM.MVVM.Model
{
    internal class Film : ObservableObject
    {
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private int _id;

        public string Tytul
        {
            get { return _tytul; }
            set
            {
                _tytul = value;
                OnPropertyChanged();
            }
        }
        private string _tytul;

        public string Opis
        {
            get { return _opis; }
            set
            {
                _opis = value;
                OnPropertyChanged();
            }
        }
        private string _opis;

        public DateTime DataPremiery
        {
            get { return _dataPremiery; }
            set
            {
                _dataPremiery = value;
                OnPropertyChanged();
            }
        }
        private DateTime _dataPremiery;
    }
}
