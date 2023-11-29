using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUISampleApp.Models
{
    public static class Calculator
    {
        public static double CalculateOperationType(double val1, double val2, string sign)
        {
            double result = 0;

            switch (sign)
            {
                case "÷":
                    result = val1 / val2;
                    break;
                case "×":
                    result = val1 * val2;
                    break;
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
            }

            return result;
        }

        //???
        public static string ExtToTrimmedString(this double target, string decimalFormat)
        {
            string strValue = target.ToString(decimalFormat); //Get the stock string

            //If there is a decimal point present
            if (strValue.Contains("."))
            {
                //Remove all trailing zeros
                strValue = strValue.TrimEnd('0');

                //If all we are left with is a decimal point
                if (strValue.EndsWith(".")) //then remove it
                    strValue = strValue.TrimEnd('.');
            }

            return strValue;
        }
    }
}
