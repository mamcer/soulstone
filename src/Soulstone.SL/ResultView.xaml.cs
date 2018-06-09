using System;
using System.Windows.Controls;

using Soulstone.SL.SoulstoneService;

namespace Soulstone.SL
{
    public partial class ResultView : UserControl
    {
        private SearchResult searchResult;
        private long LastTicks = 0; 

        public ResultView(SearchResult sr)
        {
            InitializeComponent();
            if (sr.ResultPath.Count > 1)
            {
                tbSource.Text = string.Format("{0} fuentes", sr.ResultPath.Count);
            }
            else
            {
                tbSource.Text = string.Format("{0} fuente", sr.ResultPath.Count);
            }
            this.searchResult = sr;

            tbTitle.Text = sr.TrackString;
        }

        public System.Collections.ObjectModel.ObservableCollection<MusicTrackLocation> AllSources
        {
            get
            {
                return this.searchResult.ResultPath;
            }
        }

        private void lnkMoreInfo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ShowHideMoreInfo();
        }

        private void ShowHideMoreInfo()
        {
            if (LayoutRoot.Height == 25)
            {
                SoulstoneService.SoulstoneServiceClient soulstoneService = new Soulstone.SL.SoulstoneService.SoulstoneServiceClient();
                soulstoneService.GetMusicTrackCompleted += new EventHandler<GetMusicTrackCompletedEventArgs>(soulstoneService_GetMusicTrackCompleted);
                soulstoneService.GetMusicTrackAsync(this.searchResult.MusicTrackId);
            }
            else
            {
                lnkMoreInfo.Content = "Mas info";
                LayoutRoot.Height = 25;
            }
        }

        void soulstoneService_GetMusicTrackCompleted(object sender, GetMusicTrackCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                LayoutRoot.Children.Add(new ResultViewMoreInfo(e.Result.Artist, e.Result.Year, e.Result.Album, e.Result.Genre));
                LayoutRoot.Height = 125;
                lnkMoreInfo.Content = "Menos info";
            }
        }

        private void StackPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //HACK: simulates double click
            if ((DateTime.Now.Ticks - LastTicks) < 3500000)//2310000
            {
                ShowHideMoreInfo();
            }
            LastTicks = DateTime.Now.Ticks;
        }
    }
}
