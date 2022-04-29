using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Core;

namespace WpfMVVM.MVVM.Model
{
    internal class ElementKwestii : ObservableObject
    {
    
        public string Opcja
        {
            get { return _opcja; }
            set
            {
                _opcja = value;
                OnPropertyChanged();
            }
        }
        private string _opcja;
        public int Ocena
        {
            get { return _ocena; }
            set
            {
                _ocena = value;
                OnPropertyChanged();
            }
        }
        private int _ocena;
    }
}
