
# Mead Games Launcher

O **Mead Games Launcher** é um launcher simples para Windows desenvolvido em .NET/WPF. Ele permite aos usuários instalar facilmente os jogos da Mead Games a partir de uma interface amigável.

## 📦 Funcionalidades

✅ Interface gráfica para gerenciamento de jogos  
✅ Instalação automática dos jogos disponíveis  
✅ Simples e leve  

> Atualmente o launcher **não gerencia contas nem atualiza jogos automaticamente**, apenas instala os jogos listados.

## 🔗 Download

Você pode baixar a versão mais recente aqui:  
[Repositório no GitHub](https://github.com/TwoFacexx/LauncherMeadGames)

Ou clonando diretamente:

```bash
git clone https://github.com/TwoFacexx/LauncherMeadGames
```

## 🖥️ Requisitos

- Windows 10/11
- .NET 8.0 Runtime instalado ([baixe aqui](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))

## 🚀 Como rodar

1️⃣ Baixe os arquivos do repositório.  
2️⃣ Compile usando Visual Studio ou execute o executável já gerado (`MeadGamesLauncher.exe`) na pasta `bin/Release` (se disponível).  
3️⃣ Abra o launcher, escolha o jogo desejado e clique para instalar.

## 📂 Estrutura do projeto

- `MeadGamesLauncher/Utils/DownloadManager.cs` — Gerencia os downloads e extração dos jogos.
- `Resources/` — Contém imagens usadas na interface.
- `MainWindow.xaml` — Tela principal do launcher.

## 📜 Licença

Este projeto ainda **não possui uma licença definida**. Caso queira contribuir ou utilizar, entre em contato com o autor.
