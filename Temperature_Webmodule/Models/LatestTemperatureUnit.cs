using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempraturModul.Models;

namespace TemperatureModule.Webpage.Models
{
    public class LatestTemperatureUnit
    {
        public UnitData Latest { get; set; }
        public UnitData Highest { get; set; }
        public UnitData Lowest { get; set; }

        public double Average { get; set; }
        public int NumberOfRecords { get; set; }

    }
}
