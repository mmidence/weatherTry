using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace Wunderground_API_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start program
            Console.WriteLine("Starting C# Weather Undeground Web API Test...");
            string wunderground_key = "4675ba0cfb17f954"; 

            parse("http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/AR/Searcy.xml");

            // End.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        //Takes a url request to wunderground, parses it, and displays the data.
        private static void parse(string input_xml)
        {
            
            var client = new WebClient();
            string weather = client.DownloadString(input_xml);
            //Console.WriteLine(weather);

            //Variables
            string place = "";
            string obs_time = "";
            string weather1 = "";
            string temperature_string = "";
            string relative_humidity = "";
            string wind_string = "";
            string pressure_mb = "";
            string dewpoint_string = "";
            string visibility_km = "";
            string latitude = "";
            string longitude = "";
           
            //var client = new WebClient();
            //string weather = client.DownloadString(input_xml);

            using (XmlReader reader = XmlReader.Create(new StringReader(weather)))
            {
                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name.Equals("full"))
                            {
                                reader.Read();
                                place = reader.Value;
                            }
                            else if (reader.Name.Equals("observation_time"))
                            {
                                reader.Read();
                                obs_time = reader.Value;
                            }
                            else if (reader.Name.Equals("weather"))
                            {
                                reader.Read();
                                weather1 = reader.Value;
                            }
                            else if (reader.Name.Equals("temperature_string"))
                            {
                                reader.Read();
                                temperature_string = reader.Value;
                            }
                            else if (reader.Name.Equals("relative_humidity"))
                            {
                                reader.Read();
                                relative_humidity = reader.Value;
                            }
                            else if (reader.Name.Equals("wind_string"))
                            {
                                reader.Read();
                                wind_string = reader.Value;
                            }
                            else if (reader.Name.Equals("pressure_mb"))
                            {
                                reader.Read();
                                pressure_mb = reader.Value;
                            }
                            else if (reader.Name.Equals("dewpoint_string"))
                            {
                                reader.Read();
                                dewpoint_string = reader.Value;
                            }
                            else if (reader.Name.Equals("visibility_km"))
                            {
                                reader.Read();
                                visibility_km = reader.Value;
                            }
                            else if (reader.Name.Equals("latitude"))
                            {
                                reader.Read();
                                latitude = reader.Value;
                            }
                            else if (reader.Name.Equals("longitude"))
                            {
                                reader.Read();
                                longitude = reader.Value;
                            }


                            break;
                    }
                }
            }

            Console.WriteLine("********************");
            Console.WriteLine("Place:             " + place);
            Console.WriteLine("Observation Time:  " + obs_time);
            Console.WriteLine("Weather:           " + weather1);
            Console.WriteLine("Temperature:       " + temperature_string);
            Console.WriteLine("Relative Humidity: " + relative_humidity);
            Console.WriteLine("Wind:              " + wind_string);
            Console.WriteLine("Pressure (mb):     " + pressure_mb);
            Console.WriteLine("Dewpoint:          " + dewpoint_string);
            Console.WriteLine("Visibility (km):   " + visibility_km);
            Console.WriteLine("Location:          " + longitude + ", " + latitude);
            
        }
    }
}
