﻿using Domein;
using Persistentie;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentatieLaag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _gebruikerId;
        private List<Evenement> _evenementList;
        public MainWindow(int id)
        {
            InitializeComponent();

            _gebruikerId = id;

            string constring = @"Data Source=LAPTOP-UMGHNHQ1\SQLEXPRESS;Initial Catalog=GentseFeestenA;Integrated Security=True";

            EvenementRepository repo = new EvenementRepository(constring);


            _evenementList = repo.GeefTopLevelEvenementen();

            topLevelEvtListBox.ItemsSource = _evenementList;


        }

        private void OpenPlanner_Btn(object sender, RoutedEventArgs e)
        {
            PlannerWindow plannerWindow = new PlannerWindow(_gebruikerId);
            plannerWindow.Show();
            this.Visibility = Visibility.Hidden;

        }

        
        private void ToeVoegen_Btn(object sender, RoutedEventArgs e)
        {
           
            Planner p = new Planner(_gebruikerId);

            Evenement ev = (Evenement)topLevelEvtListBox.SelectedValue;
            p.VoegEvenementToeAanPlanner(ev);


        }

    }
}
