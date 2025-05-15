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

namespace BrainStorm
{
    public partial class CreateNewPlayerWindow : Window
    {
        public Player? Player { get; set; } = null;

        public CreateNewPlayerWindow()
        {
            InitializeComponent();
        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            Player = new Player(nameTextBox.Text, datePicker.SelectedDate);
            this.Close();
        }
    }
}
