using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    public class Serviciu:ProdusAbstract
    {
        public Serviciu(int id, string? nume1, string? codIntern1, int pret1, string? categorie1):base(id, nume1, codIntern1, pret1, categorie1) { }
        public Serviciu() : base() { }
        public override string Descriere()
        {
            return "Serviciu: " + this.Nume + "[" + this.CodIntern + "] ";
        }
        public override string ToString()
        {
            return "Serviciu: " + base.ToString();
        }
        public override bool Comparare(ProdusAbstract s)
        {
            if(s is Serviciu)
            {
                return base.Comparare(s);
            }
            else
            {
                return true;
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj is Serviciu)
            {
                Serviciu serv = (Serviciu)obj;
                return base.Equals(serv);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool canAddToPackage(Pachet pachet)
        {
            if (pachet.nrServ >= Pachet.nrMaxServ)
            {
                return false;
            }
            return true;
        }
        public override void Save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, this);
            sw.Close();
        }
        public static Serviciu? loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            FileStream fs = new FileStream(fileName + ".xml", FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            
            Serviciu? serviciu = (Serviciu?)xs.Deserialize(reader);
            fs.Close();
            return serviciu;
        }
    }
}
