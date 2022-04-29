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
    internal class Zamowienie : ObservableObject
    {
        public Zamowienie()
        {
            
            Gramatura = new ObservableCollection<bool> { false, false, false, false };
            OpcjeWydruku = new ObservableCollection<bool> { false, false, false };
            TerminRealizacji = new ObservableCollection<bool> { false, false };
            isEnableKolorDruku = false;
            Naklad = 0;
            Format = 0;
            CenaFormatu = 20;
            nazwaFormatu = "A5";        
        }

        public ulong Naklad
        {
            get { return _naklad; }
            set
            {
                _naklad = value;
                PodsumowanieZamowienia();
                OnPropertyChanged();
            }
        }
        private ulong _naklad;

        public string OpisCenyFormatu
        {
            get { return _opisCenyFormatu; }
            set
            {
                _opisCenyFormatu = value;
                PodsumowanieZamowienia();
                OnPropertyChanged();
            }
        }
        private string _opisCenyFormatu;

        public string OpisPodsumowaniaZamowienia
        {
            get { return _opisPodsumowaniaZamowienia; }
            set
            {
                _opisPodsumowaniaZamowienia = value;
                OnPropertyChanged();
            }
        }
        private string _opisPodsumowaniaZamowienia;

        public bool isEnableKolorDruku
        {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                PodsumowanieZamowienia();
                OnPropertyChanged();
            }
        }
        private bool _isEnable;

        public int Format
        {
            get { return _format; }
            set
            {
                _format = value;
                AktualizacjaCenyFormatu();
                PodsumowanieZamowienia();
                OnPropertyChanged();
            }
        }
        private int _format;

        public ObservableCollection<bool> Gramatura
        {
            get { return _gramatura1; }
            set
            {
                _gramatura1 = value;
                PodsumowanieZamowienia();
                OnPropertyChanged();
            }
        }
        private ObservableCollection<bool> _gramatura1;

        public ObservableCollection<bool> OpcjeWydruku
        {
            get { return _opcjeWydruku; }
            set
            {

                _opcjeWydruku = value;
                PodsumowanieZamowienia();
                OnPropertyChanged();
            }
        }
        private ObservableCollection<bool> _opcjeWydruku;

        public ObservableCollection<bool> TerminRealizacji
        {
            get { return _terminRealizacji; }
            set
            {

                _terminRealizacji = value;
                PodsumowanieZamowienia();
                OnPropertyChanged();
            }
        }
        private ObservableCollection<bool> _terminRealizacji;

        public ulong CenaFormatu { get; set; }

        public void AktualizacjaCenyFormatu() 
        {
            if (Format == 0)
            {
                CenaFormatu = 20;
                nazwaFormatu = "A5";
            }
            else if (Format == 1)
            {
                CenaFormatu = (ulong)(20 * Math.Pow(2.5, 1));
                nazwaFormatu = "A4";
            }
            else if (Format == 2)
            {
                CenaFormatu = (ulong)(20 * Math.Pow(2.5,2));
                nazwaFormatu = "A3";
            }
            else if (Format == 3)
            {
                CenaFormatu = (ulong)(20 * Math.Pow(2.5, 3));
                nazwaFormatu = "A2";
            }
            else if (Format == 4)
            {
                CenaFormatu = (ulong)(20 * Math.Pow(2.5, 4));
                nazwaFormatu = "A1";
            }
            else if (Format == 5)
            {
                CenaFormatu = (ulong)(20 * Math.Pow(2.5, 5));
                nazwaFormatu = "A0";
            }
            OpisCenyFormatu = nazwaFormatu + " - cena " + KoncowkaPieniedzyFormat(CenaFormatu);
        }
        private string KoncowkaPieniedzyFormat(ulong monety) 
        {
            if (monety < 100)
                return monety + "gr/szt.";
            else
            {
                ulong zlotowki = monety / 100;
                ulong grosze = monety - zlotowki * 100;
                return zlotowki + "." + grosze + "zl/szt.";
            }
        }
        private string nazwaFormatu { get; set; }
        public void PodsumowanieZamowienia() 
        {
            ulong rabat;
            ulong Cena;

            Cena = (ulong)Naklad * (ulong)CenaFormatu;

            OpisPodsumowaniaZamowienia = "Przedmiot zamównienia: " + Naklad + " szt., format " + nazwaFormatu;

            if (isEnableKolorDruku)
            {
                OpisPodsumowaniaZamowienia += ", Kolorowy papier";
                Cena = (ulong)(Cena + Cena * 0.5);
            }

            //Gramatura
            if (Gramatura != null)
            {
                if (Gramatura[0] == true)
                {
                    OpisPodsumowaniaZamowienia += ", 80 g/m2";
                }
                else if (Gramatura[1] == true)
                {
                    OpisPodsumowaniaZamowienia += ", 120 g/m2";
                    Cena = (ulong)(Cena + Cena * 2);
                }
                else if (Gramatura[2] == true)
                {
                    OpisPodsumowaniaZamowienia += ", 200 g/m2";
                    Cena = (ulong)(Cena + Cena * 2.5);
                }
                else if (Gramatura[3] == true)
                {
                    OpisPodsumowaniaZamowienia += ", 240 g/m2";
                    Cena = (ulong)(Cena + Cena * 3);
                }
            }
            //Opcje wydruku
            if (OpcjeWydruku != null)
            {
                if (OpcjeWydruku[0] == true)
                {
                    OpisPodsumowaniaZamowienia += ", druk kolor";
                    Cena = (ulong)(Cena + Cena * 0.3);
                }
                if (OpcjeWydruku[1] == true)
                {
                    OpisPodsumowaniaZamowienia += ", druk dwustronny";
                    Cena = (ulong)(Cena + Cena * 0.5);
                }
                if (OpcjeWydruku[2] == true)
                {
                    OpisPodsumowaniaZamowienia += ", cakier UV";
                    Cena = (ulong)(Cena + Cena * 0.2);
                }
            }
            //TerminRealizacj
            if (TerminRealizacji != null)
            {
                if (TerminRealizacji[1] == true)
                {
                    OpisPodsumowaniaZamowienia += ", realizacja Ekspres";
                    Cena = (ulong)(Cena + Cena + 15);
                }
            }
            OpisPodsumowaniaZamowienia += "\n";
            OpisPodsumowaniaZamowienia += "Cena przed rabatem: " + KoncowkaPieniedzyFormat((ulong)Cena);
            rabat = Naklad / 100;
            if (rabat > 10)
                rabat = 10;
            double procrabat = 1 - rabat* 0.01;
            OpisPodsumowaniaZamowienia += "\n";
            OpisPodsumowaniaZamowienia += "Naliczony rabat: " + rabat + "%";

            OpisPodsumowaniaZamowienia += "\n";
            OpisPodsumowaniaZamowienia += "Cena po rabacie: " + KoncowkaPieniedzyFormat((ulong)(Cena * procrabat));

        }
    }
}
