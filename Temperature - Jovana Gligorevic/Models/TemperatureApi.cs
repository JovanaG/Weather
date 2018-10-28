using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temperature___Jovana_Gligorevic.Models
{
    public class TemperatureApi
    {
        public decimal Temperature { get; set; }
        public decimal WindDirection { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Humidity { get; set; }
        public decimal Pressure { get; set; }
        public decimal Cloudiness { get; set; }
        public decimal Fog { get; set; }
        public decimal LowClouds { get; set; }
        public decimal MediumClouds { get; set; }
        public decimal HighClouds { get; set; }
        public decimal DewpointTemperature { get; set; }
    }
}