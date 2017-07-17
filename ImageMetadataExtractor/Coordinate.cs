using System;
using System.Linq;

namespace ImageMetadataExtractor
{

    public class CoordDatum
    {
        public CoordDatum(int degrees, int min, int sec, String direction)
        {
            Degrees = degrees;
            Minutes = min;
            Seconds = sec;
            CardinalDirection = direction; 
        }
         
        public string CardinalDirection { get; private set; }
        public int Degrees { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public double ToDouble()
        {
            double decValue = Degrees + (Minutes / 60.0) + (Seconds / 3600.0);

            //if (CardinalDirection == "S" || CardinalDirection == "W")
            //    return Math.Round(-decValue,6);

            return decValue; 
        }

        public static CoordDatum fromString(String value)
        {
            var token = value.Trim().Split(' ');

            ;
            int d = int.Parse( token[0]);

            var minAsString = new string( token[1].Where(c => char.IsDigit(c)).ToArray());
            var secAsString = new string(token[2].Where(c => char.IsDigit(c)).ToArray());
            int min = int.Parse(minAsString);
            int sec = int.Parse(secAsString);
            string dir = token[3];
            return new CoordDatum(d, min, sec, dir);
        }
    }

    public class Coordinate
    {


        public Coordinate(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }
        public double Latitude { get; }
        public double Longitude { get; }

        public static Coordinate fromDegreeMinuteSecondString(String dmsString)
        {
            var cleanString = new string(dmsString.Where(c => char.IsLetterOrDigit(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c)).ToArray());

            var tokens = cleanString.Split(',');

            var latCoord = CoordDatum.fromString(tokens[0]);
            var longCoord = CoordDatum.fromString(tokens[1]);
            return new Coordinate(latCoord.ToDouble(), longCoord.ToDouble());
        }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }
    }
}
