using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Практика_6;

namespace Практика_7
{
    public class System_onl : INotifyPropertyChanged
    {
        public string doc="0";
        public string pac="0";

        public string Doc
        {
            get => doc;
            set { doc = value; OnPropertyChanged(); }
        }
        public string Pac
        {
            get => pac;
            set { pac = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
