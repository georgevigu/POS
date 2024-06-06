using manageri;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using entitati;
using filtrari;

namespace WpfPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            ProduseAbstractMgr.elemente = ProduseAbstractMgr.loadFromXML("X:\\POO\\POS\\manageri\\Save2XML");
        }

        private void ListBoxElem_Load(object sender, RoutedEventArgs e)
        {
            Fill(MainBox);
        }

        private void SorteazaPretButon_Click(object sender, RoutedEventArgs e)
        {
            MainBox.Items.Clear();
            ProduseAbstractMgr.SortareDupaPret();
            Fill(MainBox);
        }

        private void Setari_Click(object sender, RoutedEventArgs e)
        {
            Setari win2 = new Setari();
            win2.Show();
        }

        private void AdaugaElementeButon_Click(object sender, RoutedEventArgs e)
        {
            AdaugaElemente win3 = new AdaugaElemente();
            win3.Closed += SecondaryWindow_Closed;
            win3.Show();
        }

        private void SecondaryWindow_Closed(object sender, System.EventArgs e)
        {
            MainBox.Items.Clear();
            Fill(MainBox);
        }

        private void SalveazaButon_Click(object sender, RoutedEventArgs e)
        {
            ProduseAbstractMgr.Save2XML("X:\\POO\\POS\\manageri\\Save2XML");
            MessageBox.Show("Modificarile au fost salvate cu succes!");
        }

        private void Filtrare_Click(object sender, RoutedEventArgs e)
        {
            Filtrari win5 = new();
            win5.Show();
        }


        public void Fill(ListBox listbox)
        {
            foreach (ProdusAbstract pa in ProduseAbstractMgr.elemente)
            {
                listbox.Items.Add(pa);
            }
        }

        
    }


}