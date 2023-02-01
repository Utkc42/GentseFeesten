using Domein;
using Persistentie;
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

namespace PresentatieLaag
{
    /// <summary>
    /// Interaction logic for PlannerWindow.xaml
    /// </summary>
    public partial class PlannerWindow : Window
    {
        
        private List<Evenement> _evenementen = new List<Evenement>();

        public PlannerWindow(int id)
        {
            InitializeComponent();
            plannerListBox.ItemsSource = _evenementen;
        }

        private int _evenementEigenschappen;

        private void Home_Btn(object sender, RoutedEventArgs e)
        {
            MainWindow ev = new MainWindow(_evenementEigenschappen);
            this.Visibility = Visibility.Hidden;
            ev.Show();
            
        }

        
        private void VerwijderBtn(object sender, RoutedEventArgs e)
        {
            // TODO
            //Planner p = new Planner();

            //Evenement ev = (Evenement)topLevelEvtListBox.SelectedValue;
            //p.VerwijderEvenementVanPlanner(ev);
        }

        
    }
}
