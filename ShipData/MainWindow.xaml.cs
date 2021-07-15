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
        public MainWindow()
        {
            InitializeComponent();

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
            using(var db = new ApplicationDbContext())
            {
                db.Database.Migrate();
                List<Ship> ships = db.Ships.ToList();
            }
        }
    }
}
