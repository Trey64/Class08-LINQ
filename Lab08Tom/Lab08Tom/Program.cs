using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab08Tom
{
    class Program
    {
        static void Main(string[] args)
        {
            string json;

            using (StreamReader sr = File.OpenText(@"C:\Users\Tom\source\repos\Class08-LINQ\Lab08Tom\Lab08Tom\data.json"))
            {
                json = File.ReadAllText(@"C:\Users\Tom\source\repos\Class08-LINQ\Lab08Tom\Lab08Tom\data.json");
            }

            RootObject featureCollection = JsonConvert.DeserializeObject<RootObject>(json);

            Console.WriteLine("Question 1: Output all neighborhoods in this data list.");
            var allFeatures = from o in featureCollection.Features
                              where o.Properties.Neighborhood != null
                              select o;

            foreach (FeatureCollection feature in allFeatures)
            {
                Console.WriteLine(feature.Properties.Neighborhood);
            }


            Console.WriteLine();
            Console.WriteLine("Question 2: Filter out all the neighborhoods that do not have any names.");

            var namedNeighborhoods = from l in featureCollection.Features
                                     where l.Properties.Neighborhood != ""
                                     select l;

            foreach (FeatureCollection feature in namedNeighborhoods)
            {
                Console.WriteLine(feature.Properties.Neighborhood);
            }


            Console.WriteLine();
            Console.WriteLine("Question 3: Remove the Duplicates.");


            Console.WriteLine();
            Console.WriteLine("Question 4: Rewrite the queries from above, and consolidate all into one single query.");


            Console.Read();

        }


        public class Geometry
        {
            public string Type { get; set; }
            public List<double> Coordinates { get; set; }
        }

        public class Properties
        {
            public string Zip { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Address { get; set; }
            public string Borough { get; set; }
            public string Neighborhood { get; set; }
            public string County { get; set; }
        }

        public class FeatureCollection
        {
            public string Type { get; set; }
            public Geometry Geometry { get; set; }
            public Properties Properties { get; set; }
        }

        public class RootObject
        {
            public string Type { get; set; }
            public List<FeatureCollection> Features { get; set; }
        }
    }
}