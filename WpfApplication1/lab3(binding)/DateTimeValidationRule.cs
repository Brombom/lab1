using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab3_binding_
{
    class DateTimeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime s = Convert.ToDateTime(value);
            if (s < DateTime.Today)
                return new ValidationResult(false, "Дата уже прошла");
            return new ValidationResult(true, string.Empty);
        }
    }
}
