using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace entitati
{
    public abstract class ProdusAbstract : IPackageable
    {
        public int Id { get; set; }
        public string? Nume { get; set; }
        public string? CodIntern { get; set; }
        public int Pret { get; set; }
        public string? Categorie { get; set; }
        public ProdusAbstract(int id, string? nume, string? codIntern, int pret, string? categorie)
        {
            this.Id = id;
            this.Nume = nume;
            this.CodIntern = codIntern;
            this.Pret = pret;
            this.Categorie = categorie;
        }
        public ProdusAbstract() { }
        public abstract string Descriere();
        public abstract void Save2XML(string fileName);
        public override string ToString()
        {
            return this.Nume + " " + this.CodIntern + " " + this.Pret + " " + this.Categorie;
        }
        public virtual bool Comparare(ProdusAbstract s)
        {
            if (this.CodIntern == s.CodIntern && this.Nume == s.Nume)
            {
                return true;
            }
            else return false;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
            { 
                return false; 
            }
            ProdusAbstract pa = (ProdusAbstract)obj;
            return Comparare(pa);
        }
        public static bool operator == (ProdusAbstract pa1, ProdusAbstract pa2)
        {
            return pa1.Equals(pa2);
        }
        public static bool operator != (ProdusAbstract pa1, ProdusAbstract pa2)
        {
            return !pa1.Equals(pa2);
        }

        public override int GetHashCode()
        {
            if (this.CodIntern != null)
            {
                return int.Parse(this.CodIntern);
            }
            else
            {
                return 0;
            }
        }

        public virtual bool canAddToPackage(Pachet pachet)
        {
            return false;
        }
    }
}
