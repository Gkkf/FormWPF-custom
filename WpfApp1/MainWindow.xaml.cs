using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Xml.XPath;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetPlec()
        {
            if(m.IsChecked == true)
            {
                return m.Content.ToString();
            }
            else
            {
                return k.Content.ToString();
            }
        }

        private string GetZain()
        {
            string zainteresowania = "";
            if(check1.IsChecked == true)
            {
                zainteresowania += $" - {check1.Content}\n";
            }

            if (check2.IsChecked == true)
            {
                zainteresowania += $" - {check2.Content}\n";
            }

            if (check3.IsChecked == true)
            {
                zainteresowania += $" - {check3.Content}\n";
            }

            if (check4.IsChecked == true)
            {
                zainteresowania += $" - {check4.Content}\n";
            }

            return zainteresowania;
        }

        private string GetCountry()
        {
            string kraj = "";
            if (country.SelectedIndex >= 0)
            {
                switch (country.SelectedIndex)
                {
                    case 1:
                        {
                            ComboBoxItem item = (ComboBoxItem)country.SelectedItem;

                            kraj = $" - {item.Content}";

                            break;
                        }
                    case 2:
                        {
                            ComboBoxItem item = (ComboBoxItem)country.SelectedItem;

                            kraj = $" - {item.Content}";
                            break;
                        }
                    case 3:
                        {
                            ComboBoxItem item = (ComboBoxItem)country.SelectedItem;

                            kraj = $" - {item.Content}";
                            break;
                        }
                }
            }
            return kraj + "\n";
        }

        private string GetSecCountry()
        {
            string kraj = "";
            if (country2.SelectedIndex >= 0)
            {
                switch (country2.SelectedIndex)
                {
                    case 1:
                        {
                            kraj = $" - {country2.SelectedItem}";

                            break;
                        }
                    case 2:
                        {
                            kraj = $" - {country2.SelectedItem}";
                            break;
                        }
                    case 3:
                        {
                            kraj = $" - {country2.SelectedItem}";
                            break;
                        }
                }
            }
            return kraj;
        }

        private void showNew()
        {
            if (country.SelectedIndex >= 0)
            {
                switch (country.SelectedIndex)
                {
                    case 1:
                        {
                            List<string> nextSelect = new List<string>()
                            {
                                "Test1 dla Polski",
                                "Test2 dla Polski",
                                "Test2 dla Polski",
                            };

                            country2.ItemsSource = nextSelect;
                            country2.SelectedIndex = 0;
                            country2.Visibility = Visibility.Visible;

                            break;
                        }
                    case 2:
                        {
                            List<string> nextSelect = new List<string>()
                            {
                                "Test1 dla Niemcy",
                                "Test2 dla Niemcy",
                                "Test2 dla Niemcy",
                            };

                            country2.ItemsSource = nextSelect;
                            country2.SelectedIndex = 0;
                            country2.Visibility = Visibility.Visible;
                            break;
                        }
                    case 3:
                        {
                            List<string> nextSelect = new List<string>()
                            {
                                "Test1 dla Francja",
                                "Test2 dla Francja",
                                "Test2 dla Francja",
                            };

                            country2.ItemsSource = nextSelect;
                            country2.SelectedIndex = 0;
                            country2.Visibility = Visibility.Visible;
                            break;
                        }
                }
            }
        }

        private void photo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result.Content = "";
                image.Source = null;
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.DefaultExt = ".jpg";

                fileDialog.ShowDialog();

                if(firstname.Text!=String.Empty && lastname.Text!=String.Empty)
                {
                    result.Content = $"\nImie: {firstname.Text}\nNazwisko: {lastname.Text}\nData urodzenia: {age.SelectedDate.Value.ToShortDateString()}\nPłeć: {GetPlec()}\nZainteresowania:\n{GetZain()}\nKraj:\n{GetCountry()}\nMiasto:\n{GetSecCountry()}";
                    image.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(fileDialog.FileName), UriKind.RelativeOrAbsolute));
                }
            }
            catch (Exception ex)
            {
                result.Content = "Niepoprawny plik, bądź brak danych!";
            }
        }

        private void country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showNew();
        }
    }
}
