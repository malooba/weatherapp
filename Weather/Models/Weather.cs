using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Weather.Models
{
    public class WeatherData
    {
        private readonly string ep = WebConfigurationManager.AppSettings["azureEndpoint"];
        public IEnumerable<WeatherEntity> GetWeatherData()
        {
            var storageAccount = CloudStorageAccount.Parse(ep);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("esp8266");
            var query = (new TableQuery<WeatherEntity>()).Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "ESP8266"));
            var w = table.ExecuteQuery<WeatherEntity>(query);
            return w;
        }
    } 
}