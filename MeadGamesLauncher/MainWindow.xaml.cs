using MeadGamesLauncher.Models;
using MeadGamesLauncher.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MeadGamesLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CarregarJogos();
        }

        private void CarregarJogos()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "games.json");

                if (!File.Exists(jsonPath))
                {
                    MessageBox.Show("Arquivo games.json não encontrado!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string json = File.ReadAllText(jsonPath);
                List<GameInfo> jogos = JsonConvert.DeserializeObject<List<GameInfo>>(json);

                if (jogos == null || jogos.Count == 0)
                {
                    MessageBox.Show("Nenhum jogo encontrado no games.json.");
                    return;
                }

                foreach (var jogo in jogos)
                {
                    JogoCard card = new JogoCard(jogo);
                    PainelJogos.Children.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os jogos:\n" + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
