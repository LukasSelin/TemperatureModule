using System;

namespace TempraturModul.Models
{
    public class API_Inputs
    {
        public string DevEui { get; set; }
        public int? CustomerIDs { get; set; }
        public int? UnitIDs { get; set; }
        public UnitColumn Columns { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool? LastValue { get; set; }


        public override string ToString()
        {
            string returnString = "";

            if (DevEui != null)
            {
                returnString = returnString + "DevEui=" + DevEui;
            }
            else
            {
                returnString = returnString + "DevEui=" + "0018B22000003CC4";
            }

            if (CustomerIDs != null)
            {
                returnString = returnString + "&CustomerIDs=" + CustomerIDs;
            }

            if (UnitIDs != null)
            {
                returnString = returnString + "&UnitIDs=" + UnitIDs;
            }

            if (Columns != null)
            {
                returnString = returnString + "&Columns=" + Columns;
            }
            else
            {
                returnString = returnString + "&Columns=" + "%22PT=0,1%22";

            }

            if (StartDate != null)
            {
                returnString = returnString + "&StartDate=" + StartDate.ToString(@"yyyy-MM-dd\%HHmm:00");
            }

            if (StopDate != null)
            {
                returnString = returnString + "&StopDate=" + StopDate.ToString(@"yyyy-MM-dd\%HHmm:00");
            }

            if (LastValue != null)
            {
                returnString = returnString + "&LastValue";
            }

            return returnString;
        }
    }
}
