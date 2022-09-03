﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManager_2._0.ViewModels
{
    class BookDetailsFormViewModel:ViewModelBase
    {
        private string _title;
        public string Title
        {
            get 
            { 
                return _title; 
            }
            set 
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _date;
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string _genre;
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        private string _language;
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        private int _nPages;
        public int NPages
        {
            get
            {
                return _nPages;
            }
            set
            {
                _nPages = value;
                OnPropertyChanged(nameof(NPages));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private int _quantityT;
        public int QuantityT
        {
            get
            {
                return _quantityT;
            }
            set
            {
                _quantityT = value;
                OnPropertyChanged(nameof(QuantityT));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Title);

        public ICommand SumbitCommand { get; }

        public ICommand CancelCommand { get; }



    }
}
