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
    /// Interaction logic for Setari.xaml
    /// </summary>
    public partial class Setari : Window
    {
        public Setari()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Va rog selectati doar optiuni valide!");
            }
            else
            {
                Pachet.nrMaxProd = uint.Parse(comboBox1.Text);
                Pachet.nrMaxServ = uint.Parse(comboBox2.Text);
                MessageBox.Show("Modificarile au fost salvate cu succes!");
            }
        }
    }
}
