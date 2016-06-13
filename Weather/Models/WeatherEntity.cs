using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Weather.Models
{
    public class WeatherEntity : TableEntity
    {
        public WeatherEntity(string partition, DateTime utc)
        {
            PartitionKey = partition;
            RowKey = utc.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
        }

        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            Utc = properties["Utc"].DateTime.Value;
            Celsius = properties["Celsius"].DoubleValue.Value;
            Humidity = properties["Humidity"].DoubleValue.Value;
            Pressure = properties["hPa"].Int64Value.Value;
        }

        public WeatherEntity() { }

        public DateTime Utc { get; set; }

        public double Celsius { get; set; }

        public double Humidity { get; set; }

        public long Pressure { get; set; }
    }
}