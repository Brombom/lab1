using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab3_binding_
{
    class TypeOfTimeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int s = 0;
            try
            {
                s = Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "Неправильный формат");
            }
            switch (MainWindowViewModel.SelectedTime)
            {
                case "Часов":
                    {
                        if ((s < 0) || (s > 24)) return new ValidationResult(false, "Выход за границы");
                    }
                    break;
                case "Дней":
                    {
                        if ((s < 0) || (s > 365)) return new ValidationResult(false, "Выход за границы");
                    }
                    break;
                default:
                    {
                        if ((s < 0) || (s > 60)) return new ValidationResult(false, "Выход за границы");
                    }
                    break;


            }
            return new ValidationResult(true, string.Empty);
        }
    }
}
