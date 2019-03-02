using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Camp
{
    public class Camp
    {
        public readonly int id;
        public int Latitude { get; set; }
        public int Longitude {get; set;}
        public int NumberOfPoeple { get; set; }
        public int NumberOfTents { get; set; }
        public int NumberOfFlashLights { get; set; }
        private static int lastCampId = 0;

        public Camp(int latitude, int longitude, int numberOfPoeple, int numberOfTents, int numberOfFlashLights)
        {
            this.id = lastCampId++;
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPoeple = numberOfPoeple;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;
        }
        public Camp()
        {

        }
        public override string ToString()
        {
            return $"Camp Id: {id}. Latitude: {Latitude}. Longitude { Longitude}. Number Of People: {NumberOfPoeple}." +
                $"Number Of Tents: {NumberOfTents}. Number Of Flash Lights: {NumberOfFlashLights}";
        }
        public static bool operator ==(Camp c1, Camp c2)
        {
            if (c1 == null || c2 == null)
            {
                Console.WriteLine("Not Found A Camp");
                return false;
            }
            if (c1.id == c2.id)
                return true;
            return false;
        }
        public static bool operator !=(Camp c1, Camp c2)
        {
            if (c1 == null || c2 == null)
            {
                Console.WriteLine("Not Found A Camp");
                return false;
            }
            return !(c1.id == c2.id);
        }
        public static bool operator >(Camp c1, Camp c2)
        {
            if (c1.NumberOfPoeple > c2.NumberOfPoeple)
                return true;
            return false;
        }
        public static bool operator <(Camp c1, Camp c2)
        {
            if (c1.NumberOfPoeple == c2.NumberOfPoeple)
                return false;
                return !(c1.NumberOfPoeple > c2.NumberOfPoeple);
        }
        public static Camp operator +(Camp c1, Camp c2)
        {
            Camp newCamp = new Camp(c1.Latitude + c2.Latitude, c1.Longitude + c2.Longitude, c1.NumberOfPoeple + c2.NumberOfPoeple,
                c1.NumberOfTents + c2.NumberOfTents, c1.NumberOfFlashLights + c2.NumberOfFlashLights);
            return newCamp;
        }

        public override bool Equals(object obj)
        {
            Camp c = obj as Camp;
            if (this.id == c.id)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public static void SerializeACamp(string fileName, Camp campFile)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Camp));
            using (Stream file = new FileStream(fileName, FileMode.Create))
            {
                myXmlSerializer.Serialize(file, campFile);
            }
        }

        public static Camp DesrializerACamp(string fileName)
        {
            Camp newCamp = null;
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Camp));
            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                newCamp = myXmlSerializer.Deserialize(file) as Camp;
            }
            return newCamp;
        }
    }
}
