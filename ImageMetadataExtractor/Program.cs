using MetadataExtractor;
using System;
using System.IO;
using System.Linq;

namespace ImageMetadataExtractor
{
    class Program
    {
        const String API_KEY = "AIzaSyACehv0mrksfCKHRxUSJODvmfPgl-acFlA";

        static void Main(string[] args)
        {
            var image = File.OpenRead(@"images\smith-river.JPG");
            var directories = ImageMetadataReader.ReadMetadata(image);

            foreach( var dir in directories.Where(x => x.Name == "GPS"))
            {

                Console.WriteLine(dir);

                var dic = dir.Tags.ToDictionary(x => x.Name, x => x.Description);
                var latKey = "GPS Latitude";
                var latRefKey = "GPS Latitude Ref";

                var lonKey = "GPS Longitude";
                var lonRefKey = "GPS Longitude Ref";

                var utcKey = "GPS Time-Stamp";

                var lat = dic[latKey];
                var latRef = dic[latRefKey];

                var lon = dic[lonKey];
                var lonRef = dic[lonRefKey];
                var utc = dic[utcKey];

                var y = $"{lat} {latRef},{lon} {lonRef}";
                var coodWithString = Coordinate.fromDegreeMinuteSecondString(y).ToString();

                Console.WriteLine($"https://maps.googleapis.com/maps/api/geocode/json?latlng={coodWithString}&key={API_KEY}");
            }

            Console.ReadKey();

        }


    }

    
}
