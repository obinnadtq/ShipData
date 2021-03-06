using Microsoft.EntityFrameworkCore;
using ShipData.Data;
using ShipData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShipData
{
    /// <summary>
    /// Interaction logic for NewShipWindow.xaml
    /// </summary>
    public partial class NewShipWindow : Window
    {
        public NewShipWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save ship
            Ship ship = new Ship()
            {
                Name = shipNameTextBox.Text,
                Length = Convert.ToDouble(shipLengthTextBox.Text),
                Width = Convert.ToDouble(shipWidthTextBox.Text),
                Code = shipCodeTextBox.Text
            };

            using (var db = new ApplicationDbContext())
            {
                db.Ships.Add(ship);
                db.SaveChanges();
            }
           Close();
        }
    }
}
