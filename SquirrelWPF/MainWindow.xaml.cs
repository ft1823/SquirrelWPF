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
using Squirrel;

namespace SquirrelWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        UpdateManager manager;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnversion_Click(object sender, RoutedEventArgs e)
        {
            await manager.UpdateApp();

            MessageBox.Show("Updated succesfuly!");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            manager = await UpdateManager
               .GitHubUpdateManager(@"https://github.com/ft1823/SquirrelWPF");

            lblVersion.Content = "Version: " + manager.CurrentlyInstalledVersion().ToString();


            var updateInfo = await manager.CheckForUpdate();

            if (updateInfo.ReleasesToApply.Count > 0)
            {
                lblUpdateavail.Content = "Click to update";
            }
            else
            {
                lblUpdateavail.Content = "Version is updated";
            }
        }
    }
}
