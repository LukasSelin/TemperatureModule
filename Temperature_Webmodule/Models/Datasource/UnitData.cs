using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureModule.Webpage.Models
{
    public class UnitData
    {
        public int PTIndex { get; set; }
        public DateTime DataDateTime { get; set; }
        public double DataPTValue { get; set; }
    }
}
