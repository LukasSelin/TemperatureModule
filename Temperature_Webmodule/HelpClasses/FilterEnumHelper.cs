using BlazorDateRangePicker;
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


        public static DateRange GetDateRange(FilterEnum selection)
        {
            DateRange dateRange = new DateRange();
            switch (selection)
            {
                case FilterEnum.Today:
                    var today = DateTime.Today;
                    dateRange.Start = today;
                    dateRange.End = today;
                    break;

                case FilterEnum.Yesterday:
                    var yesterday = DateTime.Today.AddDays(-1);
                    dateRange.Start = yesterday;
                    dateRange.End = yesterday;

                    break;

                case FilterEnum.OneDay:
                    break;

                case FilterEnum.ThreeDays:
                    var threedaySpan = DateTime.Today.AddDays(-3);
                    dateRange.Start = threedaySpan;
                    dateRange.End = DateTime.Today;
                    break;

                case FilterEnum.OneWeek:
                    var oneWeekOffset = DateTime.Today.AddDays(-7);
                    dateRange.Start = oneWeekOffset;
                    dateRange.End = DateTime.Today;
                    break;

                case FilterEnum.TwoWeeks:
                    var twoWeeksOffset = DateTime.Today.AddDays(-14);
                    dateRange.Start = twoWeeksOffset;
                    dateRange.End = DateTime.Today;
                    break;

                case FilterEnum.OneMonth:
                    var oneMonthOffset = DateTime.Today.AddMonths(-1);
                    dateRange.Start = oneMonthOffset;
                    dateRange.End = DateTime.Today;
                    break;

                case FilterEnum.ThreeMonths:
                    var threeMonthsOffset = DateTime.Today.AddMonths(-3);
                    dateRange.Start = threeMonthsOffset;
                    dateRange.End = DateTime.Today;
                    break;

                case FilterEnum.OneYear:
                    var oneYearOffset = DateTime.Today.AddYears(-1);
                    dateRange.Start = oneYearOffset;
                    dateRange.End = DateTime.Today;
                    break;
            }
            return dateRange;
        }
        private static string GetWrittenformat(int number)
        {
            string[] numberLookup = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            return numberLookup[number];
        }
    }
}
