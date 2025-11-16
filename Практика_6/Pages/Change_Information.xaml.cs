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

namespace Практика_7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Change_Information.xaml
    /// </summary>
    public partial class Change_Information : Page
    {
        private Pacient patient = new Pacient();

        public Change_Information()
        {
            InitializeComponent();
            FindPatient.DataContext = patient;

        }

        private void Find(object sender, RoutedEventArgs e)
        {
            try
            {
                if (patient.Id != "" && patient.Id != null)
                {
                        int i = Convert.ToInt32(patient.Id);
                        string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
                        if (File.Exists(fileName))
                        {
                            string jsonString = File.ReadAllText(fileName);
                            patient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
                        patient.Id = i.ToString();
                            if (patient != null)
                            {
                                Change_pacient.DataContext = patient;
                            }
                            else
                            {
                                MessageBox.Show("Пусто(");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Такого id нет");
                        }
                }
                else
                {
                    MessageBox.Show("Пустое поле!");
                }
            }
            catch (IOException a)
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void Back_Changes(object sender, RoutedEventArgs e)
        {
            if (patient.Name != null)
            {
                int i = Convert.ToInt32(patient.Id);
                string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
                string jsonString = File.ReadAllText(fileName);
                var Bpatient = JsonSerializer.Deserialize<Pacient>(jsonString)!;
                patient.Name = Bpatient.Name;
                patient.Last_Name = Bpatient.Last_Name;
                patient.Middle_Name = Bpatient.Middle_Name;
                patient.BirthDay = Bpatient.BirthDay;
                patient.PhoneNumber = Bpatient.PhoneNumber;
            }
            else
            {
                MessageBox.Show("Нет активного пациента");
            }
        }
        private void Save_Priem(object sender, RoutedEventArgs e)
        {
            try
            {
                    var currentpacient = patient;
                    if (patient.Name != null && patient.Last_Name != null && patient.Middle_Name != null && patient.BirthDay != null )
                    {
                        int i = Convert.ToInt32(patient.Id);
                        string jsonString = JsonSerializer.Serialize(currentpacient);
                        string fileName = $"D_{i.ToString().PadLeft(7, '0')}.json";
                        File.WriteAllText(fileName, jsonString);
                        MessageBox.Show($"Ваш ID={i.ToString().PadLeft(7, '0')}");
                    }
                    else
                    {
                        MessageBox.Show($"Есть пустые поля {patient.Last_Name} {patient.Middle_Name} {patient.BirthDay} {patient.Diagnosis} {patient.Recomendations}");
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
