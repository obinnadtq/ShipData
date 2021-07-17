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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShipData.Controls
{
    /// <summary>
    /// Interaction logic for ShipControl.xaml
    /// </summary>
    public partial class ShipControl : UserControl
    {


        public Ship Ship
        {
            get { return (Ship)GetValue(ShipProperty); }
            set { SetValue(ShipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShipProperty =
            DependencyProperty.Register("Ship", typeof(Ship), typeof(ShipControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ShipControl shipControl = d as ShipControl;

            if (shipControl != null)
            {
                shipControl.nameTextBlock.Text = (e.NewValue as Ship).Name;
                shipControl.lengthTextBlock.Text = (e.NewValue as Ship).Length.ToString();
                shipControl.widthTextBlock.Text = (e.NewValue as Ship).Width.ToString();
                shipControl.codeTextBlock.Text = (e.NewValue as Ship).Code;
            }
        }

        public ShipControl()
        {
            InitializeComponent();
        }
    }
}
