using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Camp
{
    class Program
    {
        static void Main(string[] args)
        {
            Camp[] campArray = new Camp[4];
            campArray[0] = new Camp(50, 15, 4, 3, 5);
            campArray[1] = new Camp(50, 5, 6, 7, 5);
            campArray[2] = new Camp(50, 15, 4, 3, 5);
            campArray[3] = new Camp(50, 15, 4, 3, 5);


            foreach (Camp camp in campArray)
            {
                Console.WriteLine(camp);
            }


            if (campArray[0] > campArray[1])
                Console.WriteLine("c1 Bigger Than c2");
            Camp newCamp = campArray[0] + campArray[1];
            Console.WriteLine(newCamp);

            string path = "C:/temp/Camp.Xml";
            Camp.SerializeACamp(path, campArray[0]);
            Camp newCamp1 = Camp.DesrializerACamp(path);
            Camp newCamp2 = Camp.DesrializerACamp(path);

            if (ReferenceEquals(newCamp1, newCamp2))
                    Console.WriteLine(newCamp1 + newCamp2);
                else
                    Console.WriteLine("BBOOMMM");

            int a = newCamp1.GetHashCode();
            int b = newCamp2.GetHashCode();
            if (a == b)
                Console.WriteLine(a+b);
            else
                Console.WriteLine("NOT");
            }
        }
    }
