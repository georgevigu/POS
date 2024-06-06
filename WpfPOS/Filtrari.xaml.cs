using manageri;
using entitati;
using filtrari;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for Filtrari.xaml
    /// </summary>
    public partial class Filtrari : Window
    {
        public FiltrareCriteriu fc { get; set; }
        public Filtrari()
        {
            this.fc = new FiltrareCriteriu();
            InitializeComponent();
            
        }

        private void Radio1Buton_Checked(object sender, RoutedEventArgs e)
        {
            CriteriuCategorie cc = new("Categorie1");
            filt(cc);
        }

        private void Radio2Buton_Checked(object sender, RoutedEventArgs e)
        {
            CriteriuCategorie cc = new("Categorie2");
            filt(cc);
        }

        private void Radio3Buton_Checked(object sender, RoutedEventArgs e)
        {
            CriteriuCategorie cc = new("Categorie3");
            filt(cc);
        }

        public void Fill(ListBox listbox, IEnumerable<ProdusAbstract> list)
        {
            foreach (ProdusAbstract pa in list)
            {
                listbox.Items.Add(pa);
            }
        }

        private void ButonMaiMare_Checked(object sender, RoutedEventArgs e)
        {
            if(TextPret.Text == "")
            {
                return;
            }
            CriteriuPret cp = new CriteriuPret(int.Parse(TextPret.Text), '>');
            filt(cp);
        }

        private void ButonEgal_Checked(object sender, RoutedEventArgs e)
        {
            if (TextPret.Text == "")
            {
                return;
            }
            CriteriuPret cp = new CriteriuPret(int.Parse(TextPret.Text), '=');
            filt(cp);
        }

        private void ButonMaiMic_Checked(object sender, RoutedEventArgs e)
        {
            if (TextPret.Text == "")
            {
                return;
            }
            CriteriuPret cp = new CriteriuPret(int.Parse(TextPret.Text), '<');
            filt(cp);
        }

        public void filt(ICriteriu c)
        {
            IEnumerable<ProdusAbstract> temp = fc.Filtrare(ProduseAbstractMgr.elemente, c);
            Lista_Filtrata.Items.Clear();
            Fill(Lista_Filtrata, temp);
            return;
        }
    }
}
