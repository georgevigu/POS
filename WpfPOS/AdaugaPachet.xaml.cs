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
    /// Interaction logic for AdaugaPachet.xaml
    /// </summary>
    public partial class AdaugaPachet : Window
    {
        public Pachet pachet { get; set; }
        public AdaugaPachet(Pachet t)
        {
            this.pachet = t;
            InitializeComponent();
        }

        private void Adauga_PachetClick(object sender, RoutedEventArgs e)
        {
            if (Elemente_Lista.SelectedIndex == -1)
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
                    if (s.canAddToPackage(pachet))
                    {
                        pachet.Adauga(s);
                        MessageBox.Show("Elementul a fost adaugat in pachet cu succes!");
                    }
                    else
                    {
                        MessageBox.Show("Elementul nu a putut fi adaugat!");
                    }
                    return;
                case 1:
                    string producator = Producator_Box.Text;
                    Produs p = new Produs(id, nume, codIntern, producator, pret, categorie);
                    if(p.canAddToPackage(pachet))
                    {
                        pachet.Adauga(p);
                        MessageBox.Show("Elementul a fost adaugat in pachet cu succes!");
                    }
                    else
                    {
                        MessageBox.Show("Elementul nu a putut fi adaugat!");
                    }
                    return;
                default:
                    return;
            }
        }

        private void Elemente_Lista_LostMouse(object sender, MouseEventArgs e)
        {
            if (Elemente_Lista.SelectedIndex == 0)
            {
                Producator_Box.Visibility = Visibility.Hidden;
                Producator_Text.Visibility = Visibility.Hidden;
            }
            else
            {
                Producator_Box.Visibility = Visibility.Visible;
                Producator_Text.Visibility = Visibility.Visible;
            }
        }

        private void Salvare_Buton_Click(object sender, RoutedEventArgs e)
        {
            ProduseAbstractMgr.elemente.Add(pachet);
            MessageBox.Show("Pachetul a fost adaugat cu succes!");
            this.Close();
        }
    }
}
