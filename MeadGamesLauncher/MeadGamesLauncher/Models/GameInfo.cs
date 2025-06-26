using System;
using System.IO;

namespace MeadGamesLauncher.Models
{
    public class GameInfo
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string ImagemPath { get; set; }
        public string Autor { get; set; }
        public string Executavel { get; set; }
        public string DownloadUrl { get; set; }

        public string PastaInstalacao =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                         "MeadGames", "Jogos", Nome);

        public string CaminhoExecutavel =>
            Path.Combine(PastaInstalacao, Executavel);

        // Propriedade para resolver o caminho da imagem
        public string CaminhoImagemCompleto
        {
            get
            {
                // Se não houver imagem definida, usa uma imagem padrão
                if (string.IsNullOrEmpty(ImagemPath))
                {
                    // Tenta usar uma imagem padrão se existir
                    string defaultImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "default-game.png");
                    if (File.Exists(defaultImage))
                        return defaultImage;

                    return null;
                }

                // Se for caminho relativo, combina com a pasta da aplicação
                if (!Path.IsPathRooted(ImagemPath))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ImagemPath);

                    // Verifica se o arquivo existe antes de retornar
                    if (!File.Exists(fullPath))
                    {
                        // Log para debug (opcional)
                        System.Diagnostics.Debug.WriteLine($"Imagem não encontrada: {fullPath}");
                        return null;
                    }

                    return fullPath;
                }

                return ImagemPath; // Se for absoluto, retorna como está
            }
        }

        public bool EstaInstalado =>
            File.Exists(CaminhoExecutavel);
    }
}