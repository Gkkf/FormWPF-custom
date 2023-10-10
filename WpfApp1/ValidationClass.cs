using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    public class ValidationClass : ValidationRule
    {
        public static string toValidate { get; set; }

        public ValidationClass() { }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                Regex regex = new Regex("[A-Z][a-z]+");

                if(!regex.IsMatch((string)value))
                {
                    return new ValidationResult(false, "Błędne dane.");
                }
                else
                {
                    return new ValidationResult(true, "Poprawne dane.");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
        }
    }
}
