using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace BudgetTracker.WPF.Validation
{
    public class DoubleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!double.TryParse(value.ToString(), out double check))
            {
                return new ValidationResult(false, "Value must be a valid number");
            }
            return new ValidationResult(true, null);
        }
    }
}
