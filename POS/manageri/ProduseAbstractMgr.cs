using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using entitati;
using filtrari;
namespace manageri
{
    public abstract class ProduseAbstractMgr
    {
        public static List<ProdusAbstract> elemente = new List<ProdusAbstract>();
        public virtual bool Contine(ProdusAbstract p)
        {
            if (elemente.Count <= 0) return false;
            else
            {
                foreach (ProdusAbstract c in elemente) 
                {
                    if (c == p)
                    { 
                        return true; 
                    }
                }
            }
            return false;
        }

        public static void SortareDupaPret()
        {
            elemente.Sort((produs1, produs2) => produs1.Pret.CompareTo(produs2.Pret));
        }

        public static void Save2XML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[3];
            prodAbstractTypes[0] = typeof(Serviciu);
            prodAbstractTypes[1] = typeof(Produs);
            prodAbstractTypes[2] = typeof(Pachet);
            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, elemente);
            sw.Close();
        }
        public static List<ProdusAbstract>? loadFromXML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[3];
            prodAbstractTypes[0] = typeof(Serviciu);
            prodAbstractTypes[1] = typeof(Produs);
            prodAbstractTypes[2] = typeof(Pachet);
            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);

            List<ProdusAbstract>? temp = (List<ProdusAbstract>?)xs.Deserialize(reader);
            fs.Close();
            return temp;
        }

        public static void Save2JSON(string fileName)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string elementeJSON = JsonSerializer.Serialize(elemente, options);
            File.WriteAllText("C:\\Users\\rypzor\\Desktop\\projects\\POO\\POS\\app1\\" + fileName + ".json", elementeJSON);
        }
    }
}
