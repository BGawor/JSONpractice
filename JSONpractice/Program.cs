using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Device.Location;

namespace JSONpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                Console.WriteLine("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
            }
            else
            {
                Console.WriteLine("Unknown latitude and longitude.");
            }
            var url = new Uri("https://fcc-weather-api.glitch.me/api/current?lat="+ "21" + "&lon="+ "52");
            WebClient webClient = new WebClient();
            var json = new WebClient().DownloadString(url);
            dynamic weather = JsonConvert.DeserializeObject<dynamic>(json);

            Console.WriteLine("Current temperature: " + weather.weather[0].main); 
            Console.ReadLine();
        }
    }
}
