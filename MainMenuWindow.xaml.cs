using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public partial class MainMenuWindow : Window
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public PlayersHandler PlayersHandler { get; set; } = new PlayersHandler();

        public Player? ActivePlayer { get; set; } = null;

        public MainMenuWindow()
        {
            InitializeComponent();

            Players = PlayersHandler.LoadPlayers();

            if (Players.Count > 0)
            {
                foreach (Player player in Players)
                {
                    Players_comboBox.Items.Add(player.Name);
                }
            }
        }

        private void NewPlayer_button_Click(object sender, RoutedEventArgs e)
        {
            var createNewPlayerWindow = new CreateNewPlayerWindow();
            createNewPlayerWindow.ShowDialog();

            if (Players.Any(x => x.Name == createNewPlayerWindow.Player?.Name) == false)
            {
                if (createNewPlayerWindow.Player != null)
                {
                    Players.Add(createNewPlayerWindow.Player);
                    PlayersHandler.SavePlayers(Players);
                }
            }
        }

        private void Players_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivePlayer = Players.Where(p => p.Name.Equals(Players_comboBox.SelectedValue)).FirstOrDefault();
        }


        //private void Players_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ActivePlayer = Players.Where(p => p.Name.Equals(Players_comboBox.SelectedValue)).FirstOrDefault();
        //}
    }
}
