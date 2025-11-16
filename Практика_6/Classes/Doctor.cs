using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Практика_6
{
    public class Doctor : INotifyPropertyChanged
    {
        private string? cor_pass;
        [JsonIgnore]

        private string id;
        [JsonIgnore]
        private string name;
        private string last_name;
        private string middle_name;
        private string specialisation;
        private string password;

        public string Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public string Last_Name
        {
            get => last_name;
            set { last_name = value; OnPropertyChanged(); }
        }
        public string Middle_Name
        {
            get => middle_name;
            set { middle_name = value; OnPropertyChanged(); }
        }

        public string Specialisation
        {
            get => specialisation;
            set { specialisation = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get => password;
            set { password = value; OnPropertyChanged(); }
        }
        [JsonIgnore]
        public string? Cor_Password
        {
            get => cor_pass;
            set { cor_pass = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
