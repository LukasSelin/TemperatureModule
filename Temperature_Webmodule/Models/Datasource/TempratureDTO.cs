using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureModule.Webpage.Models
{
    public class TempratureDTO
    {
        public string UnitSerialNumber { get; set; }
        public List<UnitData> UnitDataPT { get; set; }

    }
}
