using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace MeadGamesLauncher.Utils
{
    public static class DownloadManager
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // ✅ AQUI sim pode usar "public"
        public static async Task BaixarEExtrairJogo(string url, string pastaDestino)
        {
            string zipPath = Path.Combine(Path.GetTempPath(), "temp_jogo.zip");

            try
            {
                if (!Directory.Exists(pastaDestino))
                    Directory.CreateDirectory(pastaDestino);

                using (HttpResponseMessage response = await httpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();

                    using (var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                }

                ZipFile.ExtractToDirectory(zipPath, pastaDestino, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao baixar ou extrair o jogo:\n" + ex.Message);
            }
            finally
            {
                if (File.Exists(zipPath))
                    File.Delete(zipPath);
            }
        }
    }
}
