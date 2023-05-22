﻿using Org.Apache.Http.Cookies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    public class Transactions : INotifyPropertyChanged
    {

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Type 
        { 
            get => type;
            set
            {
                if(type == value) 
                    return;
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private int type;

        public Double Sum 
        {
            get => sum;
            set
            {
                if (sum == value)
                    return;
                sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }
        private Double sum;

        public Account InvolvedAccounts
        {
            get => involvedAccounts;
            set
            {
                if (involvedAccounts == value)
                    return;
                involvedAccounts = value;
                OnPropertyChanged(nameof(InvolvedAccounts));
            }
        }
        private Account involvedAccounts;

        public string Category
        {
            get => category;
            set
            {
                if (category == value)
                    return;
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        private string category;

        public DateTime Date 
        {
            get => date;
            set
            {
                if (date == value)
                    return;
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private DateTime date;

        public Transactions(int type, Double sum, Account involvedAccounts, string category, DateTime date)
        {
            Type = type;
            Sum = sum;
            InvolvedAccounts = involvedAccounts;
            Category = category;
            Date = date;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
