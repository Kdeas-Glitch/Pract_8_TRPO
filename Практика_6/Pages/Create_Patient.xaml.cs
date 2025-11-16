using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Практика_6;
using Практика_7.Classes;

namespace Практика_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Create_Patient.xaml
    /// </summary>
    
    public partial class Create_Patient : Page
    {
        private Pacient npatient = new Pacient();
        private Doctor people = new Doctor();
        public int i=0;
        public Create_Patient(Doctor people)
        {
            this.people = people;
            InitializeComponent();
            Reg_pacient.DataContext = npatient;
        }

        private void Regiser_pac(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentpacient = npatient;
                if (npatient.Name != null && npatient.Last_Name != null && npatient.Middle_Name != null && npatient.BirthDay != null )
                {
                    int i = 0;
                    while (true)
                    {
                        if (File.Exists($"D_{i.ToString().PadLeft(7, '0')}.json"))
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    currentpacient.Id = $"{i}";
                    Reception r = new Reception();
                    r.Doctor_id = Convert.ToInt32(people.Id);
                    r.Date = DateTime.Now.ToString();
                    r.Diagnosis=npatient.Diagnosis;
                    r.Recomendations = npatient.Recomendations;
                    currentpacient.AppointmentStories.Add(r);
                    
                    string jsonString = JsonSerializer.Serialize(currentpacient);
                    string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
                    File.WriteAllText(fileName, jsonString);
                    MessageBox.Show($"Ваш ID={i.ToString().PadLeft(7, '0')}");
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show($"Есть пустые поля {npatient.Last_Name} {npatient.Middle_Name} {npatient.BirthDay}");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void Go_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
