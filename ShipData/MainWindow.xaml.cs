using Microsoft.EntityFrameworkCore;
using ShipData.Data;
using ShipData.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShipData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Ship> ships;
        public MainWindow()
        {
            InitializeComponent();

            ships = new List<Ship>();

            ReadShipData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewShipWindow newShipWindow = new NewShipWindow();
            newShipWindow.ShowDialog();

            ReadShipData();
        }

        void ReadShipData()
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.Migrate();
                ships = db.Ships.ToList();
            }

            if(ships != null)
            {
                shipListView.ItemsSource = ships;
            }
        }

        private void shipListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ship selectedShip = (Ship)shipListView.SelectedItem;

            if(selectedShip != null)
            {
                ShipDetailsWindow shipDetailsWindow = new ShipDetailsWindow(selectedShip);
                shipDetailsWindow.ShowDialog();
            }

            ReadShipData();
        }
    }
}
