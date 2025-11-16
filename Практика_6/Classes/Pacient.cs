using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Практика_7.Classes;

namespace Практика_7
{
    public class Pacient : INotifyPropertyChanged
    {
        private string? id;
        private string name;
        private string last_name;
        private string middle_name;
        private string birthday;
        private string phoneNumber;
        private List<Reception> appointmentStories=new List<Reception>();

        
        

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
        public string BirthDay
        {
            get => birthday;
            set { birthday = value; OnPropertyChanged(); }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set { phoneNumber = value; OnPropertyChanged(); }
        }
        public List<Reception> AppointmentStories
        {
            get => appointmentStories;
            set { appointmentStories = value; OnPropertyChanged(); }
        }


        [JsonIgnore]
        public string? Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        [JsonIgnore] public string Date;
        [JsonIgnore] public string Doctor_id;
        [JsonIgnore] public string Diagnosis { get; set; }
        [JsonIgnore] public string Recomendations { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
