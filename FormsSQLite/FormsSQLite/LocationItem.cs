using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FormsSQLite
{
    public class LocationItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
