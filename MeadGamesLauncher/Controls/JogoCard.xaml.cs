using MeadGamesLauncher.Models;
using MeadGamesLauncher.Utils;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MeadGamesLauncher.Components
{
    public partial class JogoCard : UserControl
    {
        private GameInfo jogo;

        public JogoCard(GameInfo jogoInfo)
        {
            InitializeComponent();
            jogo = jogoInfo;
            this.DataContext = jogo;

            AtualizarEstadoBotao();
        }

        private void AtualizarEstadoBotao()
        {
            // Verifica se o executável existe e muda o texto do botão
            if (File.Exists(jogo.CaminhoExecutavel))
                btnAcao.Content = "Jogar";
            else
                btnAcao.Content = "Baixar";
        }

        private async void btnAcao_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(jogo.CaminhoExecutavel))
            {
                btnAcao.IsEnabled = false;
                btnAcao.Content = "Baixando...";

                try
                {
                    await DownloadManager.BaixarEExtrairJogo(jogo.DownloadUrl, jogo.PastaInstalacao);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                finally
                {
                    btnAcao.IsEnabled = true;
                    AtualizarEstadoBotao();
                }
            }
            else
            {
                try
                {
                    Process.Start(new ProcessStartInfo(jogo.CaminhoExecutavel)
                    {
                        UseShellExecute = true
                    });
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erro ao iniciar o jogo:\n" + ex.Message);
                }
            }
        }
    }
}
