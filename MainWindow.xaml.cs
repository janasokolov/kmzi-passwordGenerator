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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        private const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NUMBERS = "0123456789";
        private const string SPECIAL_CHARACTERS = "!@#$%^&*()-_=+";
        public MainWindow()
        {

            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            int length;
            int counter=0;
            if (!int.TryParse(lengthTextBox.Text, out length) || length <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer for password length.");
                return;
            }

            bool includeLowercase = lowercaseCheckBox.IsChecked == true;
            bool includeUppercase = uppercaseCheckBox.IsChecked == true;
            bool includeNumbers = numbersCheckBox.IsChecked == true;
            bool includeSpecialChars = specialCharsCheckBox.IsChecked == true;

            if(includeLowercase) counter++;
            if(includeUppercase) counter++;
            if(includeNumbers) counter++;
            if(includeSpecialChars) counter++;

            if(length<counter)
            {
                MessageBox.Show("Password length should be greater than or equal to the number of selected character types.");
                return;
            }

            if (!includeLowercase && !includeUppercase && !includeNumbers && !includeSpecialChars)
            {
                MessageBox.Show("Please select at least one character type.");
                return;
            }

            string password = GeneratePassword(length, includeLowercase, includeUppercase, includeNumbers, includeSpecialChars);
            passwordLabel.Content = "Generated Password: " + password;
        }


        private string GeneratePassword(int length, bool includeLowercase, bool includeUppercase, bool includeNumbers, bool includeSpecialChars)
        {
            StringBuilder validChars = new StringBuilder();
            if (includeLowercase)
                validChars.Append(LOWERCASE_CHARACTERS);
            if (includeUppercase)
                validChars.Append(UPPERCASE_CHARACTERS);
            if (includeNumbers)
                validChars.Append(NUMBERS);
            if (includeSpecialChars)
                validChars.Append(SPECIAL_CHARACTERS);

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();
        }
    }
}
