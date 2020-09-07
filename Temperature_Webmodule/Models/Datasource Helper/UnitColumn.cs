using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureModule.Webpage.Models
{
    public class UnitColumn
    {
        public float PT { get; set; }
        public int Analog { get; set; }
        public float Channel { get; set; }
        public int Switch
        {
            get { return Switch; }
            set
            {
                if (value == 0 || value == 1)
                {
                    Switch = value;
                }
                else
                {
                    throw new Exception("Switch can only be either a 0 or a 1");
                }
            }
        }
        public int Formula { get; set; }
    }
}
