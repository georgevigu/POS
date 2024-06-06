using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Pachet : ProdusAbstract
    {
        public List<ProdusAbstract> Elem_pachet = new List<ProdusAbstract>();
        public uint nrProd { get; set; } = 0;
        public uint nrServ { get; set; } = 0;
        public static uint nrMaxProd { get; set; } = 1;
        public static uint nrMaxServ { get; set; } = 5;
        public Pachet(int id, string? nume, string? codIntern, int pret, string? categorie) : base(id, nume, codIntern, pret, categorie) { }
        public Pachet() { }
        public override string Descriere()
        {
            string s = "Pachet: " + this.Nume + "[" + this.CodIntern + "] ";
            // Iteram Elem_pachet
            foreach (IPackageable p in Elem_pachet)
            {
                s += p.ToString();
            }
            return s;
        }

        public void Adauga (ProdusAbstract p)
        {
            if (p is Produs)
            {
                nrProd++;
                Produs temp = (Produs)p;
                this.Pret += temp.Pret;
            }
            if (p is Serviciu)
            {
                nrServ++;
                Serviciu temp = (Serviciu)p;
                this.Pret += temp.Pret;
            }
            Elem_pachet.Add(p);
        }

        public override string ToString()
        {
            string s = "Pachet: " + base.ToString() + " contine urmatoarele:";
            foreach (IPackageable p in Elem_pachet)
            {
                s += "\n    ";
                s += p.ToString();
            }
            return s;
        }
        public override void Save2XML(string fileName)
        {
            return;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
