using System.Collections.Generic;
using TemperatureModule.Webpage.Models;

namespace TempraturModul.Models
{
    public class TempratureDTO
    {
        public string UnitSerialNumber { get; set; }
        public List<UnitData> UnitDataPT { get; set; }

    }
}
