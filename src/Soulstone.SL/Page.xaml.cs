using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Browser;
using System.Threading;

using Soulstone.SL.SoulstoneService;

namespace Soulstone.SL
{
    public partial class Page : UserControl
    {
        #region private members

        SoulstoneServiceClient soulstoneService;

        #endregion

        #region constructor

        public Page()
        {
            InitializeComponent();
        }

        #endregion

        #region private properties

        private SoulstoneServiceClient SoulstoneService
        {
            get
            {
                if (this.soulstoneService == null)
                {
                    this.soulstoneService = new SoulstoneServiceClient();
                }
                return this.soulstoneService;
            }
        }

        #endregion

        #region private methods

        private void lnkAdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            txtAdvancedSearchTitle.Text = string.Empty;
            txtAdvancedSearchArtist.Text = string.Empty;
            txtAdvancedSearchAlbum.Text = string.Empty;
            txtAdvancedSearchGenre.Text = string.Empty;
            txtAdvancedSearchYear.Text = string.Empty;
            tbStatus.Visibility = Visibility.Collapsed;
            spSearch.Visibility = Visibility.Collapsed;
            spAdvancedSearch.Visibility = Visibility.Visible;
            spResult.Visibility = Visibility.Collapsed;
            txtAdvancedSearchTitle.Focus();
        }

        private void btnCancelAdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            tbStatus.Visibility = Visibility.Collapsed;
            spAdvancedSearch.Visibility = Visibility.Collapsed;
            spSearch.Visibility = Visibility.Visible;
            spResult.Visibility = Visibility.Collapsed;
            txtSearch.Focus();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                spResult.Visibility = Visibility.Collapsed;
                tbStatus.Text = "Buscando...";
                tbStatus.Visibility = Visibility.Visible;
                SoulstoneService.SearchCompleted += new EventHandler<SearchCompletedEventArgs>(soulstoneService_SearchCompleted);
                if (rbTitle.IsChecked == true)
                {
                    soulstoneService.SearchAsync(string.Empty, string.Empty, txtSearch.Text, 0, string.Empty);
                }
                else if (rbArtist.IsChecked == true)
                {
                    soulstoneService.SearchAsync(string.Empty, txtSearch.Text, string.Empty, 0, string.Empty);
                }
                else
                {
                    SoulstoneService.SearchCompleted -= new EventHandler<SearchCompletedEventArgs>(soulstoneService_SearchCompleted);
                    tbStatus.Text = "Parámetro de busqueda incorrecto, debe seleccionar que tipo de búsqueda quiere realizarse.";
                }
            }
        }

        void soulstoneService_SearchCompleted(object sender, Soulstone.SL.SoulstoneService.SearchCompletedEventArgs e)
        {
            SoulstoneService.SearchCompleted -= new EventHandler<SearchCompletedEventArgs>(soulstoneService_SearchCompleted);
            ShowResults(e);
        }

        private void ShowResults(SearchCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                lstResult.Height = 400;
                lstResult.Items.Clear();
                spResult.Visibility = Visibility.Visible;
                SearchResultSet searchResultSet = e.Result;
                foreach (SearchResult sr in searchResultSet.SearchResults.Values)
                {
                    lstResult.Items.Add(new ResultView(sr));
                }
                tbStatus.Text = string.Format("Total {0} archivos encontrados ({1} segundos)", searchResultSet.SearchResults.Count, searchResultSet.SearchSeconds);
            }
            else
            {
                tbStatus.Text = string.Format("Ocurrió un error inesperado: {0}", e.Error.Message);
            }
        }

        private void btnAdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearch();
        }

        private void AdvancedSearch()
        {
            int year;
            if (Int32.TryParse(txtAdvancedSearchYear.Text, out year) == false)
            {
                year = 0;
            }
            if (!string.IsNullOrEmpty(txtAdvancedSearchTitle.Text) || !string.IsNullOrEmpty(txtAdvancedSearchAlbum.Text) || !string.IsNullOrEmpty(txtAdvancedSearchArtist.Text) || !string.IsNullOrEmpty(txtAdvancedSearchGenre.Text) || year != 0)
            {
                SoulstoneService.SearchCompleted += new EventHandler<SearchCompletedEventArgs>(soulstoneService_AdvancedSearchCompleted);
                spResult.Visibility = Visibility.Collapsed;
                tbStatus.Text = "Buscando...";
                tbStatus.Visibility = Visibility.Visible;
                SoulstoneService.SearchAsync(txtAdvancedSearchAlbum.Text, txtAdvancedSearchArtist.Text, txtAdvancedSearchTitle.Text, year, txtAdvancedSearchGenre.Text);
            }
        }

        void soulstoneService_AdvancedSearchCompleted(object sender, Soulstone.SL.SoulstoneService.SearchCompletedEventArgs e)
        {
            SoulstoneService.SearchCompleted -= new EventHandler<SearchCompletedEventArgs>(soulstoneService_AdvancedSearchCompleted);
            if (e.Error == null)
            {
                lstResult.Items.Clear();
                lstResult.Height = 260;
                spResult.Visibility = Visibility.Visible; 
                SearchResultSet searchResultSet = e.Result;
                foreach (SearchResult sr in searchResultSet.SearchResults.Values)
                {
                    lstResult.Items.Add(new ResultView(sr));
                }
                tbStatus.Text = string.Format("Total {0} archivos encontrados ({1} segundos)", searchResultSet.SearchResults.Count, searchResultSet.SearchSeconds);
            }
            else
            {
                tbStatus.Text = string.Format("Ocurrió un error inesperado: {0}", e.Error.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Search();
            }
        }

        private void lnkSavePlaylist_Click(object sender, RoutedEventArgs e)
        {
            if (lstResult.Items.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (ResultView rv in lstResult.Items)
                {
                    foreach (MusicTrackLocation mtl in rv.AllSources)
                    {
                        sb.AppendLine(mtl.path);
                    }
                }
                HtmlDocument doc = HtmlPage.Document;
                HtmlElement downloadData = doc.GetElementById("ctl00_BodyPlaceHolder_downloadData");
                downloadData.SetAttribute("value", sb.ToString());

                HtmlElement fileName = doc.GetElementById("ctl00_BodyPlaceHolder_fileName");
                fileName.SetAttribute("value", string.Format("{0}_pl.m3u", Guid.NewGuid()));
                doc.Submit("generateFileForm");
            }
        }

        private void AdvancedSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AdvancedSearch();
            }
        }

        #endregion
    }
}
