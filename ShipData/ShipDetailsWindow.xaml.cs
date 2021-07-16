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
    /// Interaction logic for ShipDetailsWindow.xaml
    /// </summary>
    public partial class ShipDetailsWindow : Window
    {
        Ship ship;
        public ShipDetailsWindow(Ship ship)
        {
            InitializeComponent();

            this.ship = ship;

            shipNameTextBox.Text = ship.Name;
            shipLengthTextBox.Text = ship.Length.ToString();
            shipWidthTextBox.Text = ship.Width.ToString();
            shipCodeTextBox.Text = ship.Code;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            ship.Name = shipNameTextBox.Text;
            ship.Length = Convert.ToDouble(shipLengthTextBox.Text);
            ship.Width = Convert.ToDouble(shipWidthTextBox.Text);
            ship.Code = shipCodeTextBox.Text;
            using (var db = new ApplicationDbContext())
            {
                db.Ships.Update(ship);
                db.SaveChanges();
            }

            Close();

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Ships.Remove(ship);
                db.SaveChanges();
            }

            Close();
        }
    }
}
