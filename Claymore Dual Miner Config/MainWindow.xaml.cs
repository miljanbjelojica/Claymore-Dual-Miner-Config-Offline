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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.IO.Compression;
using IWshRuntimeLibrary;

namespace Claymore_Dual_Miner_Config
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (RdNone.IsChecked == true)
            {
                txtAltAddress.IsEnabled = false;
            }
        }

        private void BtnCreateFiles_Click(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string localPath = new Uri(path).LocalPath;
            string tempFolder = Environment.GetEnvironmentVariable("temp");
            string claymoreTempLoc = tempFolder + @"\Claymore_s_Dual_Ethereum_Decred_Siacoin_Lbry_Pascal_AMD_NVIDIA_GPU_Miner_v10_0.zip";
            string claymorePath = localPath + @"\Claymore_s_Dual_Ethereum_Decred_Siacoin_Lbry_Pascal_AMD_NVIDIA_GPU_Miner_v10_0";


            OutputText createFiles = new OutputText();

            // UNZIPS CLAYMORE'S FILES TO LOCATION OF THIS EXECUTABLE
            if (System.IO.File.Exists(claymorePath + @"\Readme!!!.txt") == false)
            {
                System.IO.File.WriteAllBytes(claymoreTempLoc, Properties.Resources.Claymore_s_Dual_Ethereum_Decred_Siacoin_Lbry_Pascal_AMD_NVIDIA_GPU_Miner_v10_0);
                ZipFile.ExtractToDirectory(claymoreTempLoc, claymorePath);
            }

           if (RdETH.IsChecked == true | RdETC.IsChecked == true)
            {
                createFiles.StartBatch(claymorePath, CoinType(), altCoinType(), port(), altPort(), TxtMainAddress.Text, txtAltAddress.Text, TxtName.Text, TxtEmail.Text);
                createFiles.ePoolTextFile(claymorePath, CoinType(), port(), TxtMainAddress.Text, TxtName.Text, TxtEmail.Text);
            }

           if (RdSIA.IsChecked == true)
            {
                createFiles.dPoolTextFileSIA(claymorePath, altPort(), txtAltAddress.Text, TxtMainAddress.Text, TxtName.Text, TxtEmail.Text);
            }

           if (RdPASC.IsChecked == true)
            {
                createFiles.dPoolPASC(claymorePath, altCoinType(),altPort(), TxtMainAddress.Text, TxtName.Text, TxtEmail.Text);
            }

           // AUTO START ENABLED BY DEFAULT
            if (ChkboxAutoStart.IsChecked == true)
            {
                string appData = Environment.GetEnvironmentVariable("AppData");
                var startupFolderPath = appData + @"\Microsoft\Windows\Start Menu\Programs\Startup";

                var shell = new WshShell();
                var shortCutLinkFilePath = startupFolderPath + @"\start.lnk";

                var windowsApplicationShortcut = (IWshShortcut)shell.CreateShortcut(shortCutLinkFilePath);
                windowsApplicationShortcut.Description = "How to create short for application example";
                windowsApplicationShortcut.WorkingDirectory = claymorePath;
                windowsApplicationShortcut.TargetPath = claymorePath + @"\start.bat";
                windowsApplicationShortcut.Save();
            }

            // RETURNS TYPE OF COIN
            string CoinType()
            {
                //string[] typeOfCoin = new string[4] { "eth", "etc", "sia", "pasc" };
                string type = "";

                if (RdETH.IsChecked == true)
                {
                    type = "eth";
                }

                if (RdETC.IsChecked == true)
                {
                    type = "etc";
                }                
                return type;
            }

            // RETURNS ALT COIN TYPE
            string altCoinType()
            {                
                string type = "";

                if (RdSIA.IsChecked == true)
                {
                    type = "sia";
                }

                if (RdPASC.IsChecked == true)
                {
                    type = "pasc";
                }
                return type;
            }

            // RETURNS PORT NUMBER
            string port()
            {
                string portNumber = "";

                if (RdETH.IsChecked == true)
                {
                    portNumber = "9999";
                }

                if (RdETC.IsChecked == true)
                {
                    portNumber = "19999";
                }
                return portNumber;
            }

            string altPort()
            {
                string portNumber = "";

                if (RdSIA.IsChecked == true)
                {
                    portNumber = "7777";
                }

                if (RdPASC.IsChecked == true)
                {
                    portNumber = "15555";
                }
                return portNumber;
            }

        }

        private void RdSIA_Checked(object sender, RoutedEventArgs e)
        {
            txtAltAddress.IsEnabled = true;
        }

        private void RdPASC_Checked(object sender, RoutedEventArgs e)
        {
            txtAltAddress.IsEnabled = true;
        }

        private void RdNone_Checked(object sender, RoutedEventArgs e)
        {
            txtAltAddress.IsEnabled = false;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
    }
}
