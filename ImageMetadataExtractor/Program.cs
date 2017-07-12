using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMetadataExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = File.OpenRead(@"images\smith-river.JPG");
            var directories = ImageMetadataReader.ReadMetadata(image);

            foreach( var dir in directories)
            {
                foreach (Tag tag in dir.Tags)
                {
                    Console.WriteLine(tag);
                }
            }

            Console.ReadKey();

        }
    }
}
