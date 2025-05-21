using CmlLib.Core.Auth;
using CmlLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace KraiLauncher.View
{
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            string gamePath = Path.GetFullPath("D:\\Games\\.minecraft");
            string version = "fabric-loader-0.16.10-1.21.1";

            var path = new MinecraftPath(gamePath);
            var launcher = new MinecraftLauncher(path);

            await launcher.InstallAsync(version);

            var process = await launcher.BuildProcessAsync(version, new CmlLib.Core.ProcessBuilder.MLaunchOption
            {
                Session = MSession.CreateOfflineSession("MrLazYT"),
                MaximumRamMb = 8192,
            });

            process.Start();
        }
    }
}
