using manageri;
using entitati;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdaugaElemente.xaml
    /// </summary>
    public partial class AdaugaElemente : Window
    {
        public AdaugaElemente()
        {
            InitializeComponent();
        }

        private void Adauga_ButonClick(object sender, RoutedEventArgs e)
        {
            if(Elemente_Lista.SelectedIndex == -1)
            {
                MessageBox.Show("Va rog selectati doar optiuni valide!");
                return;
            }

            int id = ProduseAbstractMgr.elemente.Count;
            string nume = Nume_Box.Text;
            string codIntern = Cod_Box.Text;
            int pret = int.Parse(Pret_Box.Text);
            string categorie = Categorie_Box.Text;
            
            switch (Elemente_Lista.SelectedIndex)
            {
                case 0:
                    Serviciu s = new Serviciu(id, nume, codIntern, pret, categorie);
                    ProduseAbstractMgr.elemente.Add(s);
                    MessageBox.Show("Elementul a fost adaugat cu succes!");
                    return;
                case 1:
                    string producator = Producator_Box.Text;
                    Produs p = new Produs(id, nume, codIntern, producator, pret, categorie);
                    ProduseAbstractMgr.elemente.Add(p);
                    MessageBox.Show("Elementul a fost adaugat cu succes!");
                    return;
                case 2:
                    Pachet t = new Pachet(id, nume, codIntern, pret, categorie);
                    AdaugaPachet win4 = new AdaugaPachet(t);
                    win4.Show();
                    return;
                default:
                    return;
            }
        }

        private void Elemente_Lista_LostMouse(object sender, MouseEventArgs e)
        {
            if (Elemente_Lista.SelectedIndex == 0 || Elemente_Lista.SelectedIndex == 2)
            {
                Producator_Box.Visibility = Visibility.Hidden;
                Producator_Text.Visibility = Visibility.Hidden;
            }
            else
            {
                Producator_Box.Visibility = Visibility.Visible;
                Producator_Text.Visibility= Visibility.Visible;
            }
        }
    }
}
