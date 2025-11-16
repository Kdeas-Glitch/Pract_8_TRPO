using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Практика_7.Classes
{
    public class Reception : INotifyPropertyChanged
    {
        private string date;
        private int doctor_id;
        private string diagnosis;
        private string recomendations;

        public string Date
        {
            get => date;
            set { date = value; OnPropertyChanged(); }
        }
        public int Doctor_id
        {
            get => doctor_id;
            set { doctor_id = value; OnPropertyChanged(); }
        }
        public string Diagnosis
        {
            get => diagnosis;
            set { diagnosis = value; OnPropertyChanged(); }
        }
        public string Recomendations
        {
            get => recomendations;
            set { recomendations = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
