using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundJob
{
    public class Position
    {
        public int ID { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public DateTime DateTime { get; set; }
        public string Model { get; set; }
    }
}
