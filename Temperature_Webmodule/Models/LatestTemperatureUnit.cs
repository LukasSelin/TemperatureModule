using System;
using System.Collections.Generic;
using System.Linq;
using TempraturModul.Models;

namespace TemperatureModule.Webpage.Models
{
    public class LatestTemperatureUnit
    {
        public LatestTemperatureUnit(IEnumerable<UnitData> unitData)
        {
            Latest = unitData.Last();
            Highest = GetHighestRecord(unitData);
            Lowest = GetLowestRecord(unitData);

            Average = Math.Round(unitData.Average(e => e.DataPTValue), 1);
        }

        public UnitData Latest { get; set; }
        public UnitData Highest { get; set; }
        public UnitData Lowest { get; set; }

        public double Average { get; set; }

        private UnitData GetHighestRecord(IEnumerable<UnitData> units)
        {
            var data = units.Max(i => i.DataPTValue);
            var unit = units.Where(i => i.DataPTValue == data).ToArray();

            return unit[0];
        }

        private UnitData GetLowestRecord(IEnumerable<UnitData> units)
        {
            var data = units.Min(i => i.DataPTValue);
            var unit = units.Where(i => i.DataPTValue == data).ToArray();

            return unit[0];
        }
    }
}
