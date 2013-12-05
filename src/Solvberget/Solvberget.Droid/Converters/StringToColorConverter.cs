using System;
using System.Globalization;
using Android.Graphics;
using Android.Graphics.Drawables;
using Cirrious.CrossCore.Converters;

namespace Solvberget.Droid.Converters
{
    public class StringToColorConverter : MvxValueConverter<string, Color>
    {
        protected override Color Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {

                case "Min Side":
                    return new Color(0xFF, 0x99, 0x00);
                case "Arrangementer":
                    return new Color(0xCC, 0x33, 0x00);
                case "S�k":
                    return new Color(0x00, 0x55, 0x22);
                case "Blogger":
                    return new Color(0x88, 0xBB, 0x00);
                case "Nyheter":
                    return new Color(0x88, 0xBB, 0x00);
                case "Anbefalinger":
                    return new Color(0x00, 0x33, 0x66);
                case "�pningstider":
                    return new Color(0x00, 0x99, 0xCC);
                case "Kontakt oss":
                    return new Color(0x00, 0x99, 0xCC);
                default:
                    return new Color(0xCC, 0x33, 0x00);


                //case "Min Side":
                //    return new ColorDrawable(new Color(0xFF, 0x99, 0x00));
                //case "Arrangementer":
                //    return new ColorDrawable(new Color(0xCC, 0x33, 0x00));
                //case "S�k":
                //    return new ColorDrawable(new Color(0x00, 0x55, 0x22));
                //case "Blogger":
                //    return new ColorDrawable(new Color(0x88, 0xBB, 0x00));
                //case "Nyheter":
                //    return new ColorDrawable(new Color(0x88, 0xBB, 0x00));
                //case "Anbefalinger":
                //    return new ColorDrawable(new Color(0x00, 0x33, 0x66));
                //case "�pningstider":
                //    return new ColorDrawable(new Color(0x00, 0x99, 0xCC));
                //case "Kontakt oss":
                //    return new ColorDrawable(new Color(0x00, 0x99, 0xCC));
                //default:
                //    return new ColorDrawable(new Color(0xCC, 0x33, 0x00));
            }
        }
    }
}