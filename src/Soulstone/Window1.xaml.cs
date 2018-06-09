using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Soulstone.Network;
using Soulstone.Mp3;

namespace Soulstone
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Mp3FileLinkManager _mp3Manager;

        public Window1()
        {
            InitializeComponent();
            _mp3Manager = Mp3FileLinkManager.Instance;
            _mp3Manager.InitializeConnectionString(ConfigurationManager.ConnectionStrings["MusicCollectionDB"].ConnectionString);
            image2.Source = new BitmapImage(new Uri(string.Format("file://{0}/images/user.png", Environment.CurrentDirectory)));
            find.Source = new BitmapImage(new Uri(string.Format("file://{0}/images/find.png", Environment.CurrentDirectory)));
            add.Source = new BitmapImage(new Uri(string.Format("file://{0}/images/add.png", Environment.CurrentDirectory)));
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl1.SelectedIndex == tabControl1.Items.Count - 1)
            {
                TabItem ti = new TabItem();
                ti.Content = new SearchUserControl();
                ti.Header = "New playlist!";
                tabControl1.Items.Insert(tabControl1.Items.Count - 1, ti);
                tabControl1.SelectedIndex = tabControl1.Items.Count - 2;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Share anyShare in NetworkSearcher.Instance.GetSharesForComputer("HXWS137"))
            {
                if (anyShare.ShareType == ShareType.Device || anyShare.ShareType == ShareType.Disk)
                {
                    listBox1.Items.Add(string.Format("{0}", anyShare.Root.FullName));
                }
            }
        }
    }
}
