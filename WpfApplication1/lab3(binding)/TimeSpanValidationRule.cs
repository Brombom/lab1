using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab3_binding_
{
    class TimeSpanValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string t = Convert.ToString(value);
            TimeSpan s;
            try
            {
                 s = TimeSpan.Parse(t);
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "Неправильный формат");
            }
            if (s<DateTime.Now.TimeOfDay)
                return new ValidationResult(false, "Дата уже прошла");
            return new ValidationResult(true, string.Empty);
        }
    }
}
