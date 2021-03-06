using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Artikal : INotifyPropertyChanged,IDataErrorInfo
    {
        private string _sifra;
        public string Sifra
        { 
            get=>_sifra;
            set
            {
                _sifra = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sifra"));
            } 
        }
        private string _naziv;
        public string Naziv
        {
            get => _naziv;
            set
            {
                _naziv = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Naziv"));
            }
        }
        private int _kolicina;
        public int Kolicina
        {
            get => _kolicina;
            set
            {
                _kolicina = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Kolicina"));
            }
        }
        private decimal _ucena;
        public decimal Ucena
        {
            get => _ucena;
            set
            {
                _ucena = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ucena"));
            }
        }
        private int _marza;
        public int Marza
        {
            get => _marza;
            set
            {
                _marza = value;
                _cena = _ucena * ((decimal)_marza / 100 + 1);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Marza"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cena"));
            }
        }
        private int _pdv;
        public int PDV
        {
            get => _pdv;
            set
            {
                _pdv = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PDV"));
            }
        }
        private decimal _cena;
        public decimal Cena
        {
            get => _cena;
            set
            {
                _cena = value;
                _marza = (int)((_cena / _ucena - 1) * 100);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cena"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Marza"));
            }
        }

        public string Error => throw new NotImplementedException();
        private Majstor _majstor = new();
        public string this[string properti]
        {
            get
            {
                var rezultat = _majstor.Validate(this);
                var greska = rezultat.Errors
                    .Where(gr => gr.PropertyName == properti)
                    .FirstOrDefault();
                if (greska is not null)
                    return greska.ErrorMessage;
                return string.Empty;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
    public class Majstor : AbstractValidator<Artikal>
    {
        public Majstor ()
        {
            RuleFor(a => a.Cena).GreaterThan(0).WithMessage("Cena jok");
            RuleFor(a => a.Marza).GreaterThan(0).WithMessage("Marza jok");
        }
        
    }
    
}

