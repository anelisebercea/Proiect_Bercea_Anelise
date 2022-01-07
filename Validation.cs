using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Entity;
using DatabaseModel;
using System.Text.RegularExpressions;

namespace Proiect_Bercea_Anelise
{
    //validator pentru camp required
    public class StringNotEmpty : ValidationRule
    {
        //mostenim din clasa ValidationRule 
        //suprascriem metoda Validate ce returneaza un
        //ValidationResult
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureinfo)
        {
            string aString = value.ToString();
            if (aString == "")
                return new ValidationResult(false, "Campul nu poate ramane gol!");
            return new ValidationResult(true, null);
        }
    }


    //validator pentru lungime minima a string-ului
    public class StringMinLengthValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureinfo)
        {
            string aString = value.ToString();
            if (aString.Length < 3)
                return new ValidationResult(false, "Minim 3 caractere!");
        return new ValidationResult(true, null);
        }
    }


    //validator pentru email
    public class EmailValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureinfo)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            Match match = regex.Match(value.ToString());
            if (match == null || match == Match.Empty)
            {
                return new ValidationResult(false, "Introduceti un email valid!");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }

    // validator pentru data bilet
    public class DataBiletValidator : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            DateTime dataBilet = (DateTime)value;

            return new ValidationResult(dataBilet > DateTime.Now, "Data trebuie sa fie una ulterioara zilei curente!");
        }
    }


}
