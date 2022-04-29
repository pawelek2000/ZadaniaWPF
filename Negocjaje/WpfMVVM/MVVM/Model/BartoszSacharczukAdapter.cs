using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.MVVM.Model
{
    internal static class BartoszSacharczukAdapter
    {
        public static string UzyjBartka(string zawartosc)
        {
            File.WriteAllText(@"./toBartoszTextFile.txt", zawartosc);
            Process.Start("SAW.exe", "toBartoszTextFile.txt");
            return zawartosc;
        }
    }
}
