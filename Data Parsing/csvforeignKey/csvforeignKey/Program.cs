using System.Globalization;
using System.IO;
using System.Text;
using Geolocation;

namespace csvforeignKey
{
    class Program
    {
        private static void CreateStopsCsv()
        {
            var stopsRecord = new Stops();

            using (var stopsReader = new StreamReader("C:\\csv_example_data.csv"))
            {
                stopsReader.ReadLine();

                Stream csvFile = new FileStream("C:\\stops_foreign.csv", FileMode.Create, FileAccess.Write);
                var file = new StreamWriter(csvFile, Encoding.UTF8);
                var firstLine = $"id\tlon\tlat\tname\ttype\tkind\tfkey";

                file.WriteLine(firstLine);

                string currentLine;

                while ((currentLine = stopsReader.ReadLine()) != null)
                {
                    var lineItems = currentLine.Split('\t');

                    for (var i = 0; i < 6; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                stopsRecord.id = long.Parse(lineItems[0]);
                                break;
                            case 1:
                                stopsRecord.lon = double.Parse(lineItems[1], CultureInfo.InvariantCulture);
                                break;
                            case 2:
                                stopsRecord.lat = double.Parse(lineItems[2], CultureInfo.InvariantCulture);
                                break;
                            case 3:
                                stopsRecord.name = lineItems[3];
                                break;
                            case 4:
                                stopsRecord.type = lineItems[4];
                                break;
                            case 5:
                                stopsRecord.kind = lineItems[5];
                                break;
                        }
                    }
                    var foreignKey = LookFor(stopsRecord.lat, stopsRecord.lon);

                    var line =
                        $"{stopsRecord.id}\t{stopsRecord.lon}\t{stopsRecord.lat}\t{stopsRecord.name}\t{stopsRecord.type}\t{stopsRecord.kind}\t{foreignKey}";

                    file.WriteLine(line);
                }
                file.Close();
            }
        }

        private static long LookFor(double stopLat, double stopLon)
        {

            var cityRecord = new City();

            using (var cityReader = new StreamReader("C:\\testowy_miasta.csv"))
            {
                cityReader.ReadLine();

                string currentLine;

	            int id = 1;
                while ((currentLine = cityReader.ReadLine()) != null)
                {
                    var lineItems = currentLine.Split(';');

                    for (var i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                cityRecord.Id = id;
		                        id += 1;
                                break;
                            case 1:
                                cityRecord.Miasto = lineItems[0];
                                break;
                            case 2:
                                cityRecord.Lon = double.Parse(lineItems[1], CultureInfo.InvariantCulture);
                                break;
                            case 3:
                                cityRecord.Lat = double.Parse(lineItems[2], CultureInfo.InvariantCulture);
                                break;
                        }
                    }

                    var stopGeo = new Coordinate
                    {
                        Latitude = stopLat,
                        Longitude = stopLon
                    };
                    
                    var cityGeo = new Coordinate
                    {
                        Longitude = cityRecord.Lon,
                        Latitude = cityRecord.Lat
                    };

                    var distance = GeoCalculator.GetDistance(stopGeo, cityGeo, 4, DistanceUnit.Kilometers);

                    if (distance < 30)
                    {
                        return cityRecord.Id;
                    }
                }
                return 9999;
            }
        }

        static void Main()
        {
            CreateStopsCsv();
        }
    }
}
