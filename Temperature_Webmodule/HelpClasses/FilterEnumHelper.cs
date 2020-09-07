using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureModule.Webpage.Models;

namespace TemperatureModule.Webpage.HelpClasses
{
    public static class FilterEnumHelper
    {
        public static FilterEnum GetFilterEnum(string filterLabel)
        {
            if(Char.IsDigit(filterLabel[0]))
            {
                var number = Convert.ToInt32(filterLabel[0].ToString());
                var numberInLabel = GetWrittenformat(number);

                string Label = numberInLabel + filterLabel.Substring(2).First().ToString().ToUpper() + filterLabel.Substring(3);

                FilterEnum filter = (FilterEnum)Enum.Parse(typeof(FilterEnum), Label);
                return filter;
            }
            else
            {
                FilterEnum filter = (FilterEnum)Enum.Parse(typeof(FilterEnum), filterLabel);
                return filter;
            }
        }

        private static string GetWrittenformat(int number)
        {
            string[] numberLookup = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            return numberLookup[number];
        }
    }
}
