using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Soulstone.SL
{
    public partial class ResultViewMoreInfo : UserControl
    {
        public ResultViewMoreInfo(string artist, string year, string album, string genre)
        {
            InitializeComponent();
            txtAlbum.Text = album;
            txtArtist.Text = artist;
            txtYear.Text = year;
            txtGenre.Text = genre;
        }
    }
}
